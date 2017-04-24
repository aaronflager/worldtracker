using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using WorldTracker.Models;

namespace WorldTracker.Repositories
{
    public class SeedData
    {
        public static async void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();


            UserManager<WorldUser> userManager = app.ApplicationServices.GetRequiredService<UserManager<WorldUser>>();
            RoleManager<IdentityRole> roleManager = app.ApplicationServices.GetRequiredService<RoleManager<IdentityRole>>();

            if (!context.Characters.Any())
            {
                // Starter administrator account
                string firstName = "Dungeon";
                string lastName = "Master";
                string username = firstName + lastName;
                string email = "dm@email.edu";
                string password = "Secret123$";
                string role = "administrator";

                WorldUser user = await userManager.FindByNameAsync(username);
                if (user == null)
                {
                    user = new WorldUser { FirstName = firstName, LastName = lastName, UserName = username, Email = email };
                    IdentityResult result = await userManager.CreateAsync(user, password);

                    if (await roleManager.FindByNameAsync(role) == null)
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                        if (result.Succeeded)
                        {
                            await userManager.AddToRoleAsync(user, role);
                        }
                    }
                }

                // Starter member account
                firstName = "Game";
                lastName = "Player";
                username = firstName + lastName;
                email = "pc@email.edu";
                password = "Secret123$";
                role = "member";

                user = await userManager.FindByNameAsync(username);
                if (user == null)
                {
                    user = new WorldUser { FirstName = firstName, LastName = lastName, UserName = username, Email = email };
                    IdentityResult result = await userManager.CreateAsync(user, password);

                    if (await roleManager.FindByNameAsync(role) == null)
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                        if (result.Succeeded)
                        {
                            await userManager.AddToRoleAsync(user, role);
                        }
                    }
                }

                if (!context.Characters.Any())
                {
                    Character character = new Character
                    {
                        Name = "Rayna",
                        Class = "Barbarian",
                        Race = "Dwarf",
                        Background = "Tribe Member",
                        Description = "Tough and ferocious dwarven totem barbarian, follower of a badger spirit",
                        Backstory = "She escaped the clutches of an evil dwarven priest who attempted to sacrifice her to wild wood spirits, but wound up bonding with one instead. Now she seeks vengeance upon those who wronged her and killed her family"
                    };
                    context.Characters.Add(character);

                    character = new Character
                    {
                        Name = "Onyx",
                        Class = "Paladin",
                        Race = "Human",
                        Background = "Jolhondan Islander",
                        Description = "Bearing his three-headed mace of the mountains, he wears wooden full plate and still has the tattoos of his enslaved tribe on his dark and weathered skin",
                        Backstory = "The Jolhondan islanders, miners who worked for the sentient ants of the volcanic island, were enslaved and forsaken by their fire spirit. Having escaped the slave pits through wit and violence, he now seeks to redeem what he can of his people's culture and reclaim his island home"
                    };
                    context.Characters.Add(character);

                    character = new Character
                    {
                        Name = "Still",
                        Class = "Rogue",
                        Race = "Elf",
                        Background = "Spy",
                        Description = "Wrapped in dark leather armor he is never seen without his silken velvet mask, when he is seen at all. Quiet, watchful, and always with his bow at the ready",
                        Backstory = "Raised amongst the cursed elves, he bore a mask from a young age like all the others of his clan. Having shown an aptitude for stealth he was recruited by the watchful spies of his people to observe other races. Eventually, he was added to the select few of his kind that become assassins and killed for his clan"
                    };
                    context.Characters.Add(character);

                    context.SaveChanges();
                }

                if (!context.Locations.Any())
                {
                    Location location = new Location
                    {
                        Name = "Cursed Wood",
                        Description = "A forest long haunted by the spirits of the cursed elves that have lived there since creation began",
                        Geography = "Temperate Forest"
                    };
                    context.Locations.Add(location);

                    location = new Location
                    {
                        Name = "Trifeld",
                        Description = "A small, out of the way, fishing village along the northern coast of the human empire",
                        Geography = "Coastal Village"
                    };
                    context.Locations.Add(location);

                    context.SaveChanges();
                }

                if (!context.Events.Any())
                {
                    Event ev = new Event
                    {
                        Title = "The Beholder Arrives",
                        WorldDate = "12th of Swords, 1017",
                        Description = "Having conquered the frozen north, a beholder and its minions arrive on the northern coast and take up residence",
                        Site = context.Locations.FirstOrDefault(loc => loc.Name == "Trifeld")
                    };
                    context.Events.Add(ev);

                    context.SaveChanges();
                }
            }
        }
    }
}
