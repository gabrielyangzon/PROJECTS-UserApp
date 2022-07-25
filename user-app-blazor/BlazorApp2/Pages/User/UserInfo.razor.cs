using BlazorApp2.Models;
using BlazorApp2.HttpRepository;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using Microsoft.JSInterop;
namespace BlazorApp2.Pages.User
{
    public partial class UserInfo
    {

        [Inject]
        public IUserHttpRepository UserHttpRepository
        {
            get; set;
        }
   

        [Inject]
        private NavigationManager? navigationManager
        {
            get; set;
        }


        private UserModel? User;
       

        [Parameter]
        public string id
        {
            get;
            set;
        }

     

        protected override async Task OnInitializedAsync()
        {
            try
            {
               

                User = await UserHttpRepository.GetUserById(id);
            }
            catch (Exception e) { }




        }


        protected async Task SaveUser()
        {
            bool isSaved = false;

            if (await JsRuntime.InvokeAsync<bool>("confirm", $"Are you sure you want to save?"))
            {

                UserModel modifiedUser = new UserModel
                {
                    Id = (Guid)User.Id,
                    Name = User.Name,
                    Email = User.Email,
                };

                    isSaved = await UserHttpRepository.EditUser(modifiedUser);
            

                    if (isSaved)
                    {
                        await JsRuntime.InvokeVoidAsync("alert", "Saved Successfully!");
                        navigationManager.NavigateTo("users");
                    }
                    else
                    {
                        await JsRuntime.InvokeVoidAsync("alert", "Data not saved!");
                    }

                
             }
        }
    }
}
