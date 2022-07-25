using BlazorApp2.Models;
using BlazorApp2.HttpRepository;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BlazorApp2.Pages.User
{

    public partial class UserTable 
    {
        private List<UserModel>? Users;
  
        [Inject]
        public IUserHttpRepository? UserHttpRepository { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
               Users =  await UserHttpRepository.GetUsers();
               
            }
            catch(Exception e){  }
        
        }
    }
}
