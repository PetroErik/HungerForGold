using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFG.Repository
{
    /// <summary>
    /// Repository inteface.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> where T:class
    {
        /// <summary>
        /// method to get 1 instance.
        /// </summary>
        /// <param name="id">instance id.</param>
        /// <returns>an instance.</returns>
        T GetOne(int id);

        /// <summary>
        /// method to get all instance.
        /// </summary>
        /// <returns>a collection of instances.</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// a method to add new instance.
        /// </summary>
        /// <param name="newinstance">new instance.</param>
        void Addnew(T newinstance);

        /// <summary>
        /// a method to delete an instance.
        /// </summary>
        /// <param name="instance">instance.</param>
        void Delete(T instance);
    }
}
