using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace Test.Contracts.Charity.ContractDefinition
{
    public partial class Organisation : OrganisationBase { }

    public class OrganisationBase 
    {
        [Parameter("string", "name", 1)]
        public virtual string Name { get; set; }
        [Parameter("string", "desc", 2)]
        public virtual string Desc { get; set; }
        [Parameter("string", "email", 3)]
        public virtual string Email { get; set; }
        [Parameter("address", "orgAddress", 4)]
        public virtual string OrgAddress { get; set; }
        [Parameter("string", "registrationId", 5)]
        public virtual string RegistrationId { get; set; }
        [Parameter("bool", "isApproved", 6)]
        public virtual bool IsApproved { get; set; }
    }
}
