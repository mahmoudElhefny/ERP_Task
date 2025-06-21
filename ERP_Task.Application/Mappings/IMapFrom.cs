using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace ERP_Task.Application.Mappings
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile);
    }
}
