using BlazorApp2.Models;
using BlazorApp2.HttpRepository;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using Microsoft.JSInterop;

namespace BlazorApp2.Pages.User
{

    public partial class UserTable
    {
        private List<UserModel>? Users;



        [Inject]

        public NavigationManager navigationManager
        {
            get;set;
        }

        [Inject]
        public IUserHttpRepository? UserHttpRepository
        {
            get; set;
        }

        [Inject]
        public IJSRuntime jSRuntime
        {
            get; set;
        }

        public bool isLoading = true;

        public async Task GetData()
        {
            isLoading = true;
            try
            {
                Users =  await UserHttpRepository.GetUsers();

            }
            catch (Exception e) { }
            isLoading = false;
        }



        protected override async Task OnInitializedAsync()
        {
           await GetData();
          
        }

        protected async Task DeleteUser(string userId)
        {
            bool isDeleted = false;
            bool save = await jSRuntime.InvokeAsync<bool>("confirm", $"Are you sure you want to delete?");
            if (save)
            {

                isDeleted= await UserHttpRepository.DeleteUser(userId);
            }



            if (isDeleted)
            {
                await jSRuntime.InvokeVoidAsync("alert", "Deleted Successfully!");

               await GetData();
            }
            else
            {
                await jSRuntime.InvokeVoidAsync("alert", "Data not deleted!");
            }

        }


     
    }

}
