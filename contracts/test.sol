//SPDX-License-Identifier: UNLICENSED
pragma solidity ^0.8.9;

contract Charity {
    struct Organisation {
        string name;
        string desc;
        string email;
        address orgAddress;
        string registrationId;
        bool isApproved;
    }

    struct Donor {
        string name;
        string desc;
        string email;
        address donorAddress;
    }

    struct Donation {
        address donorAddress;
        address orgAddress;
        uint amount;
        uint donationId;
        uint transactionId;
        bytes32 status;
    }

    mapping(string => bool) emails;
    mapping(bytes32 => Organisation) organisations;
    mapping(bytes32 => bool) dsas;
    mapping(bytes32 => bytes32) donationStatus;

    function createOrganization(string memory _name, string memory _desc, string memory _email, string memory _registrationId) public {
        require(bytes(_name).length > 0, "Name is required.");
        require(bytes(_email).length > 0, "Email is required.");
        require(bytes(_registrationId).length > 0, "Registration ID is required.");
        require(emails[_email] == false, "User with this email already exists.");
        
        bytes32 id = keccak256(abi.encodePacked(_name, block.timestamp));
        emails[_email] = true;
        organisations[id] = Organisation(_name, _desc, _email, msg.sender, _registrationId, true);
    }

    function createDonor(string memory _name, string memory _desc, string memory _email) public {
        require(bytes(_name).length > 0, "Name is required.");
        require(bytes(_email).length > 0, "Email is required.");
        require(emails[_email] == false, "User with this email already exists.");
        
        emails[_email] = true;
        donors[msg.sender] = Donor(_name, _desc, _email, msg.sender);
    }

    function donate(address _orgAddress, uint _amount, bytes32 _dsa) public {
        require(_amount > 0, "Amount must be greater than zero.");
        require(donors[msg.sender].donorAddress != address(0), "Donor does not exist.");
        require(organisations[bytes32(uint256(uint160(_orgAddress)))].orgAddress != address(0), "Organisation does not exist.");
        bytes32 donationStatusId = keccak256(abi.encodePacked(_orgAddress, _amount, _dsa, block.timestamp));
        require(dsas[_dsa] == true, "DSA is not authorized to donate");
        donationStatus[donationStatusId] = "Donation Received";
        uint donationId = donations.length + 1;
        donations.push(Donation(msg.sender, _orgAddress, _amount, donationId, 0, donationStatusId));
    }

    function approveOrganisation(bytes32 _id) public {
        require(organisations[_id].orgAddress == msg.sender, "Not authorized to approve organisation.");
        
        organisations[_id].isApproved = true;
    }

    function getOrganisation(bytes32 _id) public view returns (Organisation memory) {
        require(organisations[_id].orgAddress != address(0), "Organisation does not exist.");
        
        return organisations[_id];
    }

    function getStatus(bytes32 _donationStatusId) public view returns (bytes32) {
        return donationStatus[_donationStatusId];
    }
    function add(uint256 a, uint256 b) public pure returns(uint256){
        return a + b;
    }
    function substract(uint256 x, uint256 y) public pure returns(uint256){
        return x     + y;
    }
    mapping(address => Donor) donors;
    Donation[] donations;
}