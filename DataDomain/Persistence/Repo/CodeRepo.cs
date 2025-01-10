using DataDomain.Data.Context;
using DataDomain.Data.entity;
using Microsoft.EntityFrameworkCore;


namespace DataDomain.Persistence.Repo
{
    public interface ICodeRepo
    {
        public Code AddCode(Guid clientId, string value);
        public Code? GetCodeByClientId(Guid clienId);
        public void UpdateCode(Code code, string value);
    }
    public class CodeRepo : ICodeRepo
    {
        DSContext context;
        public CodeRepo(DSContext context) {
            this.context = context;
        }

        public Code? GetCodeByClientId(Guid clienId)
        {
            return context.Codes.FirstOrDefault(code => code.ClientId == clienId);
        }

        public Code AddCode(Guid clientId, string value)
        {
            Code codeEnt = new()
            {
                Value = value,
                UpdatedAt = DateTime.Now.ToUniversalTime(),
                ValidUntil = DateTime.Now.AddMinutes(15).ToUniversalTime(),
                ClientId = clientId,
            };

            context.Codes.Add(codeEnt);
            return codeEnt;
        }

        public void UpdateCode(Code code, string value)
        {
            code.Value = value;
            code.UpdatedAt = DateTime.UtcNow;
            code.ValidUntil = DateTime.UtcNow.AddMinutes(15);

            context.Codes.Update(code);

        }
    }
}
