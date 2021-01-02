﻿using DemoProjectDesktopUI.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DemoProjectDesktopUI.Library.Api
{


    public class SaleEndPoint : ISaleEndPoint
    {
        private IAPIHelper _apiHelper;

        public SaleEndPoint(IAPIHelper apiHelper)
        {
            _apiHelper = apiHelper;

        }
        public async Task PostSale(SaleModel sale)
        {
            using (HttpResponseMessage response = await _apiHelper.ApiClient.PostAsJsonAsync("/Sale", sale))
            {
                if (response.IsSuccessStatusCode)
                {
                    //
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }


}
