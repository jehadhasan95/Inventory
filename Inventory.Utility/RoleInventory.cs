﻿using Inventory.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Utility
{
    public class RoleInventory : IRoleInventory
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<AppUser> _userManager;

        public RoleInventory(RoleManager<IdentityRole> roleManager,
            UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task AddRoleAsync(string AppUserId)
        {
            var user = await _userManager.FindByIdAsync(AppUserId);
            var roles = _roleManager.Roles;
            List<string> StringRoles = new List<string>();
            if (user != null)
            {
                foreach (var item in roles)
                {
                    await _userManager.AddToRoleAsync(user, item.Name);
                }
                
            }
        }
        public async Task CreateNewRoleAsync()
        {
            Type t = typeof(TopMenu);
            foreach (Type classObj in t.GetNestedTypes())
            { 
                foreach (var objField in classObj.GetFields())
                {
                    if (objField.Name.Contains("RoleName"))
                    {
                        var roleName = (string)objField.GetValue(objField);
                        if (!await _roleManager.RoleExistsAsync(roleName))
                            await _roleManager.CreateAsync(new IdentityRole(roleName));

                    }
                }
            }
        }
    }
}
