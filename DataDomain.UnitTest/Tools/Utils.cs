using DataDomain.Data.Context;
using DataDomain.Data.entity;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDomain.UnitTest.Tools;

public interface IUtils
{
    public Client AddClient(string userName, string password, string email);
    public void ClearChanges();
    public Code? GetCode(Guid clientId);
}

public class Utils : IUtils
{
    PGContext context;
    public Utils(PGContext ctx)
    {
        context = ctx;
    }

    public Client AddClient(string userName, string password, string email)
    {
        Client cli = new()
        {
            Email = email,
            UserName = userName,
            Password = password,
            CreatedAt = DateTime.Now.ToUniversalTime(),
        };

        context.Clients.Add(cli);
        context.SaveChanges();
        return cli;

    }

    public void ClearChanges()
    {
        context.ChangeTracker.Clear();
    }

    public Code? GetCode(Guid clientId)
    {
        Code? code = context.Codes.FirstOrDefault(code => code.ClientId == clientId);

        return code;
    }
}
