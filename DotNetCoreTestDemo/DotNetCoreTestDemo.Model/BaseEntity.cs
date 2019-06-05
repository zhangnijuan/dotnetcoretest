using System;

namespace DotNetCoreTestDemo.Model
{
    public class BaseEntity<T>
    {
        public T Id { get; set; }
        public bool IsDelete { get; set; }
        public DateTime CreateTime { get; set; }=DateTime.Now;
    }
}
