using EMS.Core.Helpers;

namespace EMS.Core.Domain.Entities
{
    public abstract class BaseDto<TKey>
    {
        public TKey Id { get; set; }
        public byte LocationId { get; set; }
        public EntityState EntityState { get; set; }
    }
}