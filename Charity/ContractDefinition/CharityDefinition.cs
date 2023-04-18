using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace Test.Contracts.Charity.ContractDefinition
{


    public partial class CharityDeployment : CharityDeploymentBase
    {
        public CharityDeployment() : base(BYTECODE) { }
        public CharityDeployment(string byteCode) : base(byteCode) { }
    }

    public class CharityDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "608060405234801561001057600080fd5b50611161806100206000396000f3fe608060405234801561001057600080fd5b50600436106100625760003560e01c806304291e721461006757806349c29920146100905780635de28ae0146100a557806394096ed5146100d3578063977ef86b146100e6578063c791c83d146100f9575b600080fd5b61007a610075366004610c14565b61010c565b6040516100879190610c7d565b60405180910390f35b6100a361009e366004610dc3565b61044a565b005b6100c56100b3366004610c14565b60009081526003602052604090205490565b604051908152602001610087565b6100a36100e1366004610c14565b6105d8565b6100a36100f4366004610e4b565b610672565b6100a3610107366004610e8c565b6109ce565b6101506040518060c0016040528060608152602001606081526020016060815260200160006001600160a01b03168152602001606081526020016000151581525090565b6000828152600160205260409020600301546001600160a01b03166101bc5760405162461bcd60e51b815260206004820152601c60248201527f4f7267616e69736174696f6e20646f6573206e6f742065786973742e0000000060448201526064015b60405180910390fd5b60008281526001602052604090819020815160c081019092528054829082906101e490610f39565b80601f016020809104026020016040519081016040528092919081815260200182805461021090610f39565b801561025d5780601f106102325761010080835404028352916020019161025d565b820191906000526020600020905b81548152906001019060200180831161024057829003601f168201915b5050505050815260200160018201805461027690610f39565b80601f01602080910402602001604051908101604052809291908181526020018280546102a290610f39565b80156102ef5780601f106102c4576101008083540402835291602001916102ef565b820191906000526020600020905b8154815290600101906020018083116102d257829003601f168201915b5050505050815260200160028201805461030890610f39565b80601f016020809104026020016040519081016040528092919081815260200182805461033490610f39565b80156103815780601f1061035657610100808354040283529160200191610381565b820191906000526020600020905b81548152906001019060200180831161036457829003601f168201915b505050918352505060038201546001600160a01b031660208201526004820180546040909201916103b190610f39565b80601f01602080910402602001604051908101604052809291908181526020018280546103dd90610f39565b801561042a5780601f106103ff5761010080835404028352916020019161042a565b820191906000526020600020905b81548152906001019060200180831161040d57829003601f168201915b50505091835250506005919091015460ff16151560209091015292915050565b600083511161048f5760405162461bcd60e51b81526020600482015260116024820152702730b6b29034b9903932b8bab4b932b21760791b60448201526064016101b3565b60008151116104d55760405162461bcd60e51b815260206004820152601260248201527122b6b0b4b61034b9903932b8bab4b932b21760711b60448201526064016101b3565b6000816040516104e59190610f73565b9081526040519081900360200190205460ff16156105155760405162461bcd60e51b81526004016101b390610f8f565b60016000826040516105279190610f73565b9081526040805160209281900383018120805460ff19169415159490941790935560808301815285835281830185905282810184905233606084018190526000908152600490925290208151819061057f9082611022565b50602082015160018201906105949082611022565b50604082015160028201906105a99082611022565b5060609190910151600390910180546001600160a01b0319166001600160a01b03909216919091179055505050565b6000818152600160205260409020600301546001600160a01b031633146106515760405162461bcd60e51b815260206004820152602760248201527f4e6f7420617574686f72697a656420746f20617070726f7665206f7267616e6960448201526639b0ba34b7b71760c91b60648201526084016101b3565b6000908152600160208190526040909120600501805460ff19169091179055565b600082116106cc5760405162461bcd60e51b815260206004820152602160248201527f416d6f756e74206d7573742062652067726561746572207468616e207a65726f6044820152601760f91b60648201526084016101b3565b336000908152600460205260409020600301546001600160a01b031661072c5760405162461bcd60e51b81526020600482015260156024820152742237b737b9103237b2b9903737ba1032bc34b9ba1760591b60448201526064016101b3565b6001600160a01b03838116600090815260016020526040902060030154166107965760405162461bcd60e51b815260206004820152601c60248201527f4f7267616e69736174696f6e20646f6573206e6f742065786973742e0000000060448201526064016101b3565b6040516bffffffffffffffffffffffff19606085901b166020820152603481018390526054810182905242607482015260009060940160408051601f1981840301815291815281516020928301206000858152600290935291205490915060ff1615156001146108485760405162461bcd60e51b815260206004820152601f60248201527f445341206973206e6f7420617574686f72697a656420746f20646f6e6174650060448201526064016101b3565b600081815260036020526040812070111bdb985d1a5bdb88149958d95a5d9959607a1b905560055461087b9060016110e2565b6040805160c0810182523381526001600160a01b03978816602082019081529181019687526060810192835260006080820181815260a08301968752600580546001810182559252915160069091027f036b6384b5eca791c62761152d0c79bb0604c104a5fb6f4eb0703f3154bb3db081018054928b166001600160a01b031993841617905592517f036b6384b5eca791c62761152d0c79bb0604c104a5fb6f4eb0703f3154bb3db18401805491909a1691161790975594517f036b6384b5eca791c62761152d0c79bb0604c104a5fb6f4eb0703f3154bb3db2860155517f036b6384b5eca791c62761152d0c79bb0604c104a5fb6f4eb0703f3154bb3db38501555092517f036b6384b5eca791c62761152d0c79bb0604c104a5fb6f4eb0703f3154bb3db48301555090517f036b6384b5eca791c62761152d0c79bb0604c104a5fb6f4eb0703f3154bb3db590910155565b6000845111610a135760405162461bcd60e51b81526020600482015260116024820152702730b6b29034b9903932b8bab4b932b21760791b60448201526064016101b3565b6000825111610a595760405162461bcd60e51b815260206004820152601260248201527122b6b0b4b61034b9903932b8bab4b932b21760711b60448201526064016101b3565b6000815111610aaa5760405162461bcd60e51b815260206004820152601c60248201527f526567697374726174696f6e2049442069732072657175697265642e0000000060448201526064016101b3565b600082604051610aba9190610f73565b9081526040519081900360200190205460ff1615610aea5760405162461bcd60e51b81526004016101b390610f8f565b60008442604051602001610aff929190611109565b6040516020818303038152906040528051906020012090506001600084604051610b299190610f73565b9081526040805160209281900383018120805460ff19169415159490941790935560c08301815287835281830187905282810186905233606084015260808301859052600160a0840181905260008581529252902081518190610b8c9082611022565b5060208201516001820190610ba19082611022565b5060408201516002820190610bb69082611022565b5060608201516003820180546001600160a01b0319166001600160a01b0390921691909117905560808201516004820190610bf19082611022565b5060a091909101516005909101805460ff19169115159190911790555050505050565b600060208284031215610c2657600080fd5b5035919050565b60005b83811015610c48578181015183820152602001610c30565b50506000910152565b60008151808452610c69816020860160208601610c2d565b601f01601f19169290920160200192915050565b602081526000825160c06020840152610c9960e0840182610c51565b90506020840151601f1980858403016040860152610cb78383610c51565b92506040860151915080858403016060860152610cd48383610c51565b60608701516001600160a01b031660808781019190915287015186820390920160a087015292509050610d078282610c51565b91505060a0840151151560c08401528091505092915050565b634e487b7160e01b600052604160045260246000fd5b600082601f830112610d4757600080fd5b813567ffffffffffffffff80821115610d6257610d62610d20565b604051601f8301601f19908116603f01168101908282118183101715610d8a57610d8a610d20565b81604052838152866020858801011115610da357600080fd5b836020870160208301376000602085830101528094505050505092915050565b600080600060608486031215610dd857600080fd5b833567ffffffffffffffff80821115610df057600080fd5b610dfc87838801610d36565b94506020860135915080821115610e1257600080fd5b610e1e87838801610d36565b93506040860135915080821115610e3457600080fd5b50610e4186828701610d36565b9150509250925092565b600080600060608486031215610e6057600080fd5b83356001600160a01b0381168114610e7757600080fd5b95602085013595506040909401359392505050565b60008060008060808587031215610ea257600080fd5b843567ffffffffffffffff80821115610eba57600080fd5b610ec688838901610d36565b95506020870135915080821115610edc57600080fd5b610ee888838901610d36565b94506040870135915080821115610efe57600080fd5b610f0a88838901610d36565b93506060870135915080821115610f2057600080fd5b50610f2d87828801610d36565b91505092959194509250565b600181811c90821680610f4d57607f821691505b602082108103610f6d57634e487b7160e01b600052602260045260246000fd5b50919050565b60008251610f85818460208701610c2d565b9190910192915050565b60208082526024908201527f557365722077697468207468697320656d61696c20616c72656164792065786960408201526339ba399760e11b606082015260800190565b601f82111561101d57600081815260208120601f850160051c81016020861015610ffa5750805b601f850160051c820191505b8181101561101957828155600101611006565b5050505b505050565b815167ffffffffffffffff81111561103c5761103c610d20565b6110508161104a8454610f39565b84610fd3565b602080601f831160018114611085576000841561106d5750858301515b600019600386901b1c1916600185901b178555611019565b600085815260208120601f198616915b828110156110b457888601518255948401946001909101908401611095565b50858210156110d25787850151600019600388901b60f8161c191681555b5050505050600190811b01905550565b8082018082111561110357634e487b7160e01b600052601160045260246000fd5b92915050565b6000835161111b818460208801610c2d565b919091019182525060200191905056fea2646970667358221220d7ca5e8160eb25a0a69292667ec513efaa773bebfc5a1dc00020d0c5ef1a88d864736f6c63430008130033";
        public CharityDeploymentBase() : base(BYTECODE) { }
        public CharityDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class ApproveOrganisationFunction : ApproveOrganisationFunctionBase { }

    [Function("approveOrganisation")]
    public class ApproveOrganisationFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "_id", 1)]
        public virtual byte[] Id { get; set; }
    }

    public partial class CreateDonorFunction : CreateDonorFunctionBase { }

    [Function("createDonor")]
    public class CreateDonorFunctionBase : FunctionMessage
    {
        [Parameter("string", "_name", 1)]
        public virtual string Name { get; set; }
        [Parameter("string", "_desc", 2)]
        public virtual string Desc { get; set; }
        [Parameter("string", "_email", 3)]
        public virtual string Email { get; set; }
    }

    public partial class CreateOrganizationFunction : CreateOrganizationFunctionBase { }

    [Function("createOrganization")]
    public class CreateOrganizationFunctionBase : FunctionMessage
    {
        [Parameter("string", "_name", 1)]
        public virtual string Name { get; set; }
        [Parameter("string", "_desc", 2)]
        public virtual string Desc { get; set; }
        [Parameter("string", "_email", 3)]
        public virtual string Email { get; set; }
        [Parameter("string", "_registrationId", 4)]
        public virtual string RegistrationId { get; set; }
    }

    public partial class DonateFunction : DonateFunctionBase { }

    [Function("donate")]
    public class DonateFunctionBase : FunctionMessage
    {
        [Parameter("address", "_orgAddress", 1)]
        public virtual string OrgAddress { get; set; }
        [Parameter("uint256", "_amount", 2)]
        public virtual BigInteger Amount { get; set; }
        [Parameter("bytes32", "_dsa", 3)]
        public virtual byte[] Dsa { get; set; }
    }

    public partial class GetOrganisationFunction : GetOrganisationFunctionBase { }

    [Function("getOrganisation", typeof(GetOrganisationOutputDTO))]
    public class GetOrganisationFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "_id", 1)]
        public virtual byte[] Id { get; set; }
    }

    public partial class GetStatusFunction : GetStatusFunctionBase { }

    [Function("getStatus", "bytes32")]
    public class GetStatusFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "_donationStatusId", 1)]
        public virtual byte[] DonationStatusId { get; set; }
    }









    public partial class GetOrganisationOutputDTO : GetOrganisationOutputDTOBase { }

    [FunctionOutput]
    public class GetOrganisationOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple", "", 1)]
        public virtual Organisation ReturnValue1 { get; set; }
    }

    public partial class GetStatusOutputDTO : GetStatusOutputDTOBase { }

    [FunctionOutput]
    public class GetStatusOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }
}