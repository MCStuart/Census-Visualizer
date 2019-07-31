using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StateMigration.Data;
using StateMigration.Models;

namespace StateMigration.Controllers

{
    public class StateMigrationsController : Controller
    {
        private readonly StateMigrationContext _context;

        public StateMigrationsController(StateMigrationContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.States.ToListAsync());
        }