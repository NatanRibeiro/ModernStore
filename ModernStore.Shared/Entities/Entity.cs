using FluentValidator;
using System;

namespace ModernStore.Shared.Entities
{
    public  abstract class Entity : Notifiable
    {
        protected Entity()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
    }
}
