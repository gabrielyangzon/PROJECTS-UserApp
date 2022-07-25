using BlazorApp2.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorApp2.Components
{
    public partial class Table
    {

        [Parameter]
        public List<UserModel> data
        {
            get;
            set;
        }


        

    }
}
