using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Service;

namespace Service
{
    public class AspNetUserService:  GenericService<AspNetUser, string>
    {

        public AspNetUser GetLoggedinUserDetails(string UserName)
        {



            var query = (from user in this.repository.Get()
                         where user.UserName.ToLower().Trim() == UserName.ToLower().Trim()
                         select new AspNetUser
                         {
                             UserName = user.UserName,
                             AspNetRoles = user.AspNetRoles,
                             //UserFranchises = user.UserFranchises,
                             //UserGeos = user.UserGeos,
                            // UserLocalizeSettings = user.UserLocalizeSettings,
                             Id = user.Id
                         }).FirstOrDefault();


            if (query == null)
            {
                return query;
            }

            //foreach (var role in query.AspNetRoles)
            //{
            //    var roleid = role.Id;
            //    role.ApplicationRolePermissions = this.Context.ApplicationRolePermissions.Where(m => m.RoleId == roleid).ToList();
            //    List<int> applicationExistingPages = role.ApplicationRolePermissions.Select(m => m.PageId.Value).ToList();
            //    var newPages = this.Context.ApplicationPages.Where(m => !applicationExistingPages.Contains(m.ApplicationPageId)).ToList();

            //    var newPermission = newPages.Select(m => new ApplicationRolePermission()
            //    {
            //        PageId = m.ApplicationPageId,
            //        OperationId = 1,
            //        RoleId = roleid,
            //        ApplicationPage = new ApplicationPage() { PageName = m.PageName, ApplicationPageId = m.ApplicationPageId }
            //    }).ToList();

            //    role.ApplicationRolePermissions = newPermission.Union(role.ApplicationRolePermissions).ToList();

            //}




            //if (query.UserGeos.Count > 0)
            //{
            //    int geoid = query.UserGeos.First().GeoId.Value;
            //    List<int> geoids = this.Context.Geos.Where(m => m.GeoID == geoid || m.ParentID == geoid).Select(m => m.GeoID).ToList();
            //    var newuserFranchies = this.Context.FranchiseGeos.Where(m => geoids.Contains(m.GeoID.Value)).Select(m => new { UserId = query.Id, FranchiseId = m.FranchiseID });

            //    foreach (var f in newuserFranchies)
            //    {
            //        query.UserFranchises.Add(new UserFranchis() { FranchiseId = f.FranchiseId, UserId = f.UserId });
            //    }

            //}

            //if (query.UserGeos.Count == 0 && query.UserFranchises.Count == 0)
            //{
            //    var newuserFranchies = this.Context.Franchises.Where(m => true).Select(m => new { UserId = query.Id, FranchiseId = m.FranchiseID });
            //    foreach (var f in newuserFranchies)
            //    {
            //        query.UserFranchises.Add(new UserFranchis() { FranchiseId = f.FranchiseId, UserId = f.UserId });
            //    }

            //}
            //if (query.UserLocalizeSettings.Count > 0)
            //{
            //    int localizeSettingId = query.UserLocalizeSettings.First().LocalizeSettingId.Value;
            //    var localizeSettings = this.Context.LocalizeSettings.Where(m => m.Id == localizeSettingId).First();
            //    foreach (var f in query.UserLocalizeSettings)
            //    {
            //        f.LocalizeSetting = localizeSettings;
            //    }
            //}
            return query;
        }

        public bool UpdateUser(AspNetUser entity)
        {
            var usercheck = this.Get().Where(m => m.UserName == entity.UserName && m.Id != entity.Id);

            if (usercheck.Count() > 0)
            {
                return false;
            }

            AspNetUser user = this.GetById(entity.Id);

            user.Email = entity.Email;
            user.UserName = entity.UserName;

            repository.Context.Entry(user).State = System.Data.Entity.EntityState.Modified;
            repository.SaveChanges();


            this.Context.Database.ExecuteSqlCommand("delete from UserFranchises where UserId = '" + entity.Id + "'");
            this.Context.Database.ExecuteSqlCommand("delete from UserGeo where UserId = '" + entity.Id + "'");
            this.Context.Database.ExecuteSqlCommand("delete from AspNetUserRoles where UserId = '" + entity.Id + "'");
            this.Context.Database.ExecuteSqlCommand("delete from UserLocalizeSettings where UserId = '" + entity.Id + "'");

            this.Context.Database.ExecuteSqlCommand("insert into AspNetUserRoles (UserId,RoleId) values ('" + entity.Id + "','" + entity.AspNetRoles.First().Id + "')");


            //if (entity.UserFranchises != null)
            //{
            //    foreach (var franchise in entity.UserFranchises)
            //    {
            //        franchise.UserId = entity.Id;
            //        this.Context.UserFranchises.Add(franchise);
            //        repository.SaveChanges();
            //    }
            //}

            //if (entity.UserGeos != null)
            //{
            //    foreach (var geo in entity.UserGeos)
            //    {
            //        geo.UserId = entity.Id;
            //        this.Context.UserGeos.Add(geo);
            //        repository.SaveChanges();
            //    }
            //}
            //if (entity.UserLocalizeSettings != null)
            //{
            //    foreach (var geo in entity.UserLocalizeSettings)
            //    {
            //        geo.UserId = entity.Id;
            //        this.Context.UserLocalizeSettings.Add(geo);
            //        repository.SaveChanges();
            //    }
            //}

            return true;

        }
    }
}
