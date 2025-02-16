﻿using Microsoft.AspNetCore.Identity;
using Trabalho_Pratico_23_24.Models;

namespace Trabalho_Pratico_23_24.Data
{
    public enum Roles
    {
        Administrador,
        Gestor,
        Funcionario,
        Cliente
    }
    public static class Inicializacao
    {
        public static async Task CriaDadosIniciais(UserManager<ApplicationUser>
       userManager, RoleManager<IdentityRole> roleManager)
        {
            Console.WriteLine("Vim aquiii \n \n \n");
            //Adicionar default Roles
            await roleManager.CreateAsync(new IdentityRole(Roles.Administrador.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Gestor.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Funcionario.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Cliente.ToString()));
            //Adicionar Default User - Admin
            var defaultUser = new ApplicationUser
            {
                UserName = "admin@localhost.com",
                Email = "admin@localhost.com",
                PrimeiroNome = "Administrador",
                UltimoNome = "Local",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                DataNascimento = DateTime.Today,
                NIF = 1234321
                
            };
            var user = await userManager.FindByEmailAsync(defaultUser.Email);
            if (user == null)
            {
                
                await userManager.CreateAsync(defaultUser, "Is3C..00");
                await userManager.AddToRoleAsync(defaultUser,
                Roles.Administrador.ToString());
            }
        }
    }

}
