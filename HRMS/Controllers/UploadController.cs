using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.DirectoryServices.AccountManagement;
namespace HRMS
{
    public class UploadController : BaseController
    {
        /// <summary>
        /// Upload a file and return a JSON result
        /// </summary>
        /// <param name="file">The file to upload.</param>
        /// <returns>a FileUploadJsonResult</returns>
        /// <remarks>
        /// It is not possible to upload files using the browser's XMLHttpRequest
        /// object. So the jQuery Form Plugin uses a hidden iframe element. For a
        /// JSON response, a ContentType of application/json will cause bad browser
        /// behavior so the content-type must be text/html. Browsers can behave badly
        /// if you return JSON with ContentType of text/html. So you must surround
        /// the JSON in textarea tags. All this is handled nicely in the browser
        /// by the jQuery Form Plugin. But we need to overide the default behavior
        /// of the JsonResult class in order to achieve the desired result.
        /// </remarks>
        /// <seealso cref="http://malsup.com/jquery/form/#code-samples"/>
        /// 

        
        public FileUploadJsonResult AjaxUpload(HttpPostedFileBase file)
        {
            if (Request.Form["taskExcel"] == "true")
            {
                return ExcelUpload(file);
            }
            else
            {
                try
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        // extract only the fielname 
                        var fileName = System.IO.Path.GetFileName(file.FileName);

                        if (fileName.Contains("!") || fileName.Contains("@") || fileName.Contains("#") || fileName.Contains("$") || fileName.Contains("%") || fileName.Contains("^") || fileName.Contains("&") || fileName.Contains("*") || fileName.Contains("+"))
                        {
                            throw new Exception("The filename may not contain the following characters: !,@,#,$,%,^,&,*,+");
                        };

                        Random random = new Random(DateTime.Now.Second);
                        string path = "";
                        string rootPath = ConfigurationManager.AppSettings["RootUploadPath"];

                        path = Request.Form["uploadPath"];
                        string enforceName = Request.Form["enforceName"];

                        // System Throwing Strange Error, may be the beta, wrapping in try catch
                        try
                        {
                            System.IO.Directory.CreateDirectory(rootPath + path);
                        }
                        catch
                        {
                        }

                        try
                        {
                            System.IO.Directory.CreateDirectory(rootPath + path + "\\Archive");
                        }
                        catch
                        {
                        }


                        if (System.IO.File.Exists(rootPath + path + "\\" + fileName))
                        {
                            if (enforceName != null)
                            {
                                throw new Exception("File name already exists");
                            }
                            int randNum = random.Next();
                            for (int i = 0; i < 10000; i++)
                            {
                                if (!System.IO.File.Exists(rootPath + path + "\\Archive\\" + fileName.Split('.')[0] + randNum.ToString() + "." + fileName.Split('.')[1]))
                                {
                                    System.IO.File.Copy(rootPath + path + "\\" + fileName, rootPath + path + "\\Archive\\" + fileName.Split('.')[0] + randNum.ToString() + "." + fileName.Split('.')[1]);
                                    System.IO.File.Delete(rootPath + path + "\\" + fileName);
                                    break;
                                }
                            }
                        }

                        // store the file inside ~/App_Data/uploads folder 
                        var tempPath = System.IO.Path.Combine(rootPath + path, fileName);
                        file.SaveAs(tempPath);

                        // Return JSON
                        return new FileUploadJsonResult { Data = new { message = string.Format("{0} uploaded successfully.", System.IO.Path.GetFileName(file.FileName)), fileName = file.FileName } };
                    }

                    return null;
                }
                catch (Exception ex)
                {
                    return new FileUploadJsonResult { Data = new { message = string.Format("Uploading Error: {0}", ex.Message.ToString()) } };
                }
            }
        }

        public FileUploadJsonResult ExcelUpload(HttpPostedFileBase file)
        {
            try
            {
                if (file != null && file.ContentLength > 0)
                {
                    // extract only the fielname
                    DateTime dt = DateTime.Now;


                    var fileName = "Excel" + dt.Ticks.ToString() + ".xlsx";  //System.IO.Path.GetFileName(file.FileName);

                    string path = "";
                    string rootPath = "C:\\PivotDocuments\\";

                    if (Request.Form["uploadPath"] == String.Empty)
                    {
                        throw new Exception("No uploadPath variable specified in the upload form");
                    }
                    else
                    {
                        path = Request.Form["uploadPath"];
                    }

                    int projectId = 0;
                    if (Request.Form["uploadProjectId"] == String.Empty)
                    {
                        throw new Exception("No projectId available");
                    }
                    else
                    {
                        projectId = Convert.ToInt32(Request.Form["uploadProjectId"].ToString());
                    }

                    // store the file inside ~/App_Data/uploads folder 
                    var tempPath = System.IO.Path.Combine(rootPath + path, fileName);
                    file.SaveAs(tempPath);

                    //TaskService ts = new TaskService();
                    //ts.importExcel(tempPath, projectId);

                    // Return JSON
                    return new FileUploadJsonResult { Data = new { message = string.Format("{0} uploaded successfully.", fileName), fileName = fileName } };
                }

                return null;
            }
            catch (Exception ex)
            {
                return new FileUploadJsonResult { Data = new { message = string.Format("Uploading Error: {0}", ex.Message.ToString()) } };
            }
        }

        //public FileResult DownloadFile(int fileDocumentID)
        //{
        //    Service.EventDocumentReferenceService service = new Service.EventDocumentReferenceService();
        //    Model.EventDocumentReference doc = service.GetById(fileDocumentID);
        //    return File(doc.DocContent, "application/octet-stream", doc.FileName);

        //}
    }

    public class FileUploadJsonResult : JsonResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            this.ContentType = "text/html";
            context.HttpContext.Response.Write("<textarea>");
            base.ExecuteResult(context);
            context.HttpContext.Response.Write("</textarea>");
        }
    }
}
