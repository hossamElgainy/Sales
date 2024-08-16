using Domain.DomainModels;
using SalesProject.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specification
{
    public class GetSaledProductsSpecification:BaseSpecification<Sales>
    {
        public GetSaledProductsSpecification()
        {
            Includes.Add(z => z.Product);   
        }
    }
}
