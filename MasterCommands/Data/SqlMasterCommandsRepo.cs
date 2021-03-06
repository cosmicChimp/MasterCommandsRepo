﻿using MasterCommands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterCommands.Data
{
    public class SqlMasterCommandsRepo : IMasterCommandsRepo
    {
        private readonly MasterCommandsContext _context;

        public SqlMasterCommandsRepo(MasterCommandsContext context)
        {
            _context = context;
        }

        public void CreateCommand(Command cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Commands.Add(cmd);
        }

        public void DeleteCommand(Command downcmd)
        {
            if (downcmd == null)
            {
                throw new ArgumentNullException(nameof(downcmd));
            }
            _context.Commands.Remove(downcmd);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCommand(Command upcmd)
        {
            // Nothing, yet...
        }
    }
}
