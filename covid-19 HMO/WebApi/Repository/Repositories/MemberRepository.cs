using Repository.Entities;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class MemberRepository : IRepository<Member>
    {
        private readonly IContext _context;
        public MemberRepository(IContext context)
        {
            this._context = context;
        }
        public Member Add(Member entity)
        {
            this._context.Members.Add(entity);
            this._context.Save();
            return entity;
        }

        public void Delete(int id)
        {
            var member=this._context.Members.FirstOrDefault(m=>m.Id==id);
            if (member != null)
            {
                this._context.Members.Remove(member);
                this._context.Save();
            }
        }

        public Member Get(int id)
        {
            return this._context.Members.FirstOrDefault(m => m.Id == id);
        }

        public List<Member> GetAll()
        {
            return this._context.Members.ToList();
        }

        public Member Update(int id, Member entity)
        {
            var prev = Get(id);
            if (prev != null)
            {
                prev.Name = entity.Name;
                prev.IdNumber = entity.IdNumber;
                prev.City = entity.City;
                prev.Street = entity.Street;
                prev.HouseNumber = entity.HouseNumber;
                prev.BirthDate = entity.BirthDate;
                prev.Phone = entity.Phone;
                prev.MobilePhone = entity.MobilePhone;
                prev.DateOfSickness = entity.DateOfSickness;
                prev.DateOfRecovery = entity.DateOfRecovery;
            }
            else
            {
                this._context.Members.Add(entity);
            }

            this._context.Save();
            return entity;
        }
    }
}
