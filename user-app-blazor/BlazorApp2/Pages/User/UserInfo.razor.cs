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
        public IJSRuntime IJSRuntime
        {
            get; set;
        }

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
                if (id == "0")
                {
                    User = new UserModel();
                }
                else
                {

                    User = await UserHttpRepository.GetUserById(id);

                }
            }
            catch (Exception e) {
            
            
            
            }




        }

        public async Task SaveUser()
        {
            bool isSaved = false;
            bool save = await IJSRuntime.InvokeAsync<bool>("confirm", $"Are you sure you want to save?");
            if (save)
            {

                UserModel modifiedUser = new UserModel
                {
                    Id = (Guid)User.Id,
                    Name = User.Name,
                    Email = User.Email,
                    Phone = User.Phone,
                };

                if (User.Id.ToString() != "0")
                {
                    isSaved = await UserHttpRepository.EditUser(modifiedUser);
                }
                else
                {
                    isSaved = await UserHttpRepository.AddUser(modifiedUser);
                }
                   
            

                    if (isSaved)
                    {
                        await IJSRuntime.InvokeVoidAsync("alert", "Saved Successfully!");
                        navigationManager.NavigateTo("users");
                    }
                    else
                    {
                        await IJSRuntime.InvokeVoidAsync("alert", "Data not saved!");
                    }

                
             }

            return;
        }
    }
}
