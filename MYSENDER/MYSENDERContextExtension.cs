using Microsoft.EntityFrameworkCore;
using MYSENDER.Models;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using MYSENDER.DatabaseModels;

namespace MYSENDER
{
    public static class MySenderContextExtension
    {
        public static async Task<Response> SaveChangesResponseAsync(this MYSENDERContext ctx)
        {
            var success = true;
            var nb = 0;
            var modifications = 0;

            try
            {
                var result = await ctx.SaveChangesAsync();
                modifications = result;
            }
            catch (Exception ex)
            {
                var updex = (DbUpdateException)ex.InnerException;
                var sqlex = (SqlException)updex?.InnerException;

                success = false;
                nb = sqlex?.Number ?? 0;
                //LogService.Instance.WriteError(ex);
            }
            return new Response
            {
                Success = success,
                Code = nb,
                Modifications = modifications
            };
        }
    }
}
