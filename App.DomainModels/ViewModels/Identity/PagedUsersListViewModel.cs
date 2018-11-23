using App.DomainModels.Entities.Identity;
using cloudscribe.Web.Pagination;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.DomainModels.ViewModels.Identity
{
    public class PagedUsersListViewModel
    {
        public PagedUsersListViewModel()
        {
            Paging = new PaginationSettings();
        }

        public List<User> Users { get; set; }

        public List<Role> Roles { get; set; }

        public PaginationSettings Paging { get; set; }
    }
}
