//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Product.DAO
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Apartment : DbContext
    {
        public Apartment()
            : base("name=Apartment")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tblApartment> tblApartment { get; set; }
        public virtual DbSet<tblContract> tblContract { get; set; }
        public virtual DbSet<tblEmployee> tblEmployee { get; set; }
        public virtual DbSet<tblFamily> tblFamily { get; set; }
        public virtual DbSet<tblMember> tblMember { get; set; }
        public virtual DbSet<tblContractDetail> tblContractDetail { get; set; }
        public virtual DbSet<tblService> tblService { get; set; }
        public virtual DbSet<tblServiceBill> tblServiceBill { get; set; }
        public virtual DbSet<tblPermission> tblPermission { get; set; }
        public virtual DbSet<tblPerRelationship> tblPerRelationship { get; set; }
        public virtual DbSet<tblUser> tblUser { get; set; }
    
        public virtual int deleteApartment(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("deleteApartment", idParameter);
        }
    
        public virtual int deleteEmployee(Nullable<int> empId)
        {
            var empIdParameter = empId.HasValue ?
                new ObjectParameter("empId", empId) :
                new ObjectParameter("empId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("deleteEmployee", empIdParameter);
        }
    
        public virtual int deleteFamily(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("deleteFamily", idParameter);
        }
    
        public virtual int deleteMember(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("deleteMember", idParameter);
        }
    
        public virtual ObjectResult<getAparment_Result> getAparment()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getAparment_Result>("getAparment");
        }
    
        public virtual ObjectResult<getApart_Result> getApart()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getApart_Result>("getApart");
        }
    
        public virtual ObjectResult<getEmployee_Result> getEmployee()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getEmployee_Result>("getEmployee");
        }
    
        public virtual ObjectResult<getFamily_Result> getFamily()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getFamily_Result>("getFamily");
        }
    
        public virtual ObjectResult<Nullable<int>> getMaxIdEmp()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("getMaxIdEmp");
        }
    
        public virtual ObjectResult<getMember_Result> getMember()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getMember_Result>("getMember");
        }
    
        public virtual ObjectResult<getPermission_Result> getPermission()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getPermission_Result>("getPermission");
        }
    
        public virtual ObjectResult<getUser_Result> getUser()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getUser_Result>("getUser");
        }
    
        public virtual ObjectResult<getUserLogin_Result> getUserLogin(string uuid, string pwd)
        {
            var uuidParameter = uuid != null ?
                new ObjectParameter("uuid", uuid) :
                new ObjectParameter("uuid", typeof(string));
    
            var pwdParameter = pwd != null ?
                new ObjectParameter("pwd", pwd) :
                new ObjectParameter("pwd", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getUserLogin_Result>("getUserLogin", uuidParameter, pwdParameter);
        }
    
        public virtual int insertApartment(string apartId, Nullable<double> price, Nullable<double> area, string note, string image, Nullable<bool> status, Nullable<int> familyId)
        {
            var apartIdParameter = apartId != null ?
                new ObjectParameter("apartId", apartId) :
                new ObjectParameter("apartId", typeof(string));
    
            var priceParameter = price.HasValue ?
                new ObjectParameter("price", price) :
                new ObjectParameter("price", typeof(double));
    
            var areaParameter = area.HasValue ?
                new ObjectParameter("area", area) :
                new ObjectParameter("area", typeof(double));
    
            var noteParameter = note != null ?
                new ObjectParameter("note", note) :
                new ObjectParameter("note", typeof(string));
    
            var imageParameter = image != null ?
                new ObjectParameter("image", image) :
                new ObjectParameter("image", typeof(string));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("status", status) :
                new ObjectParameter("status", typeof(bool));
    
            var familyIdParameter = familyId.HasValue ?
                new ObjectParameter("familyId", familyId) :
                new ObjectParameter("familyId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insertApartment", apartIdParameter, priceParameter, areaParameter, noteParameter, imageParameter, statusParameter, familyIdParameter);
        }
    
        public virtual int insertEmployee(string empName, Nullable<bool> gender, string address, string phone, Nullable<System.DateTime> dob, string email, string identityNumber, Nullable<int> departmentId, string image)
        {
            var empNameParameter = empName != null ?
                new ObjectParameter("empName", empName) :
                new ObjectParameter("empName", typeof(string));
    
            var genderParameter = gender.HasValue ?
                new ObjectParameter("gender", gender) :
                new ObjectParameter("gender", typeof(bool));
    
            var addressParameter = address != null ?
                new ObjectParameter("address", address) :
                new ObjectParameter("address", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("phone", phone) :
                new ObjectParameter("phone", typeof(string));
    
            var dobParameter = dob.HasValue ?
                new ObjectParameter("dob", dob) :
                new ObjectParameter("dob", typeof(System.DateTime));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var identityNumberParameter = identityNumber != null ?
                new ObjectParameter("identityNumber", identityNumber) :
                new ObjectParameter("identityNumber", typeof(string));
    
            var departmentIdParameter = departmentId.HasValue ?
                new ObjectParameter("departmentId", departmentId) :
                new ObjectParameter("departmentId", typeof(int));
    
            var imageParameter = image != null ?
                new ObjectParameter("image", image) :
                new ObjectParameter("image", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insertEmployee", empNameParameter, genderParameter, addressParameter, phoneParameter, dobParameter, emailParameter, identityNumberParameter, departmentIdParameter, imageParameter);
        }
    
        public virtual int insertFamily(string familyId, string familyName, Nullable<int> numberMember)
        {
            var familyIdParameter = familyId != null ?
                new ObjectParameter("familyId", familyId) :
                new ObjectParameter("familyId", typeof(string));
    
            var familyNameParameter = familyName != null ?
                new ObjectParameter("familyName", familyName) :
                new ObjectParameter("familyName", typeof(string));
    
            var numberMemberParameter = numberMember.HasValue ?
                new ObjectParameter("numberMember", numberMember) :
                new ObjectParameter("numberMember", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insertFamily", familyIdParameter, familyNameParameter, numberMemberParameter);
        }
    
        public virtual int insertMember(string memberId, string name, Nullable<bool> gender, string email, string identityNumber, string image, Nullable<System.DateTime> dob, string phone, Nullable<int> familyId)
        {
            var memberIdParameter = memberId != null ?
                new ObjectParameter("memberId", memberId) :
                new ObjectParameter("memberId", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var genderParameter = gender.HasValue ?
                new ObjectParameter("gender", gender) :
                new ObjectParameter("gender", typeof(bool));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var identityNumberParameter = identityNumber != null ?
                new ObjectParameter("identityNumber", identityNumber) :
                new ObjectParameter("identityNumber", typeof(string));
    
            var imageParameter = image != null ?
                new ObjectParameter("image", image) :
                new ObjectParameter("image", typeof(string));
    
            var dobParameter = dob.HasValue ?
                new ObjectParameter("dob", dob) :
                new ObjectParameter("dob", typeof(System.DateTime));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("phone", phone) :
                new ObjectParameter("phone", typeof(string));
    
            var familyIdParameter = familyId.HasValue ?
                new ObjectParameter("familyId", familyId) :
                new ObjectParameter("familyId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insertMember", memberIdParameter, nameParameter, genderParameter, emailParameter, identityNumberParameter, imageParameter, dobParameter, phoneParameter, familyIdParameter);
        }
    
        public virtual ObjectResult<searchFamily_Result> searchFamily(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<searchFamily_Result>("searchFamily", idParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual int updateApartment(Nullable<int> id, string apartId, Nullable<double> price, Nullable<double> area, string note, string image, Nullable<bool> status, Nullable<int> familyId)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var apartIdParameter = apartId != null ?
                new ObjectParameter("apartId", apartId) :
                new ObjectParameter("apartId", typeof(string));
    
            var priceParameter = price.HasValue ?
                new ObjectParameter("price", price) :
                new ObjectParameter("price", typeof(double));
    
            var areaParameter = area.HasValue ?
                new ObjectParameter("area", area) :
                new ObjectParameter("area", typeof(double));
    
            var noteParameter = note != null ?
                new ObjectParameter("note", note) :
                new ObjectParameter("note", typeof(string));
    
            var imageParameter = image != null ?
                new ObjectParameter("image", image) :
                new ObjectParameter("image", typeof(string));
    
            var statusParameter = status.HasValue ?
                new ObjectParameter("status", status) :
                new ObjectParameter("status", typeof(bool));
    
            var familyIdParameter = familyId.HasValue ?
                new ObjectParameter("familyId", familyId) :
                new ObjectParameter("familyId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("updateApartment", idParameter, apartIdParameter, priceParameter, areaParameter, noteParameter, imageParameter, statusParameter, familyIdParameter);
        }
    
        public virtual int updateEmployee(Nullable<int> empId, string empName, Nullable<bool> gender, string address, string phone, Nullable<System.DateTime> dob, string email, string identityNumber, Nullable<int> departmentId, string image)
        {
            var empIdParameter = empId.HasValue ?
                new ObjectParameter("empId", empId) :
                new ObjectParameter("empId", typeof(int));
    
            var empNameParameter = empName != null ?
                new ObjectParameter("empName", empName) :
                new ObjectParameter("empName", typeof(string));
    
            var genderParameter = gender.HasValue ?
                new ObjectParameter("gender", gender) :
                new ObjectParameter("gender", typeof(bool));
    
            var addressParameter = address != null ?
                new ObjectParameter("address", address) :
                new ObjectParameter("address", typeof(string));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("phone", phone) :
                new ObjectParameter("phone", typeof(string));
    
            var dobParameter = dob.HasValue ?
                new ObjectParameter("dob", dob) :
                new ObjectParameter("dob", typeof(System.DateTime));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var identityNumberParameter = identityNumber != null ?
                new ObjectParameter("identityNumber", identityNumber) :
                new ObjectParameter("identityNumber", typeof(string));
    
            var departmentIdParameter = departmentId.HasValue ?
                new ObjectParameter("departmentId", departmentId) :
                new ObjectParameter("departmentId", typeof(int));
    
            var imageParameter = image != null ?
                new ObjectParameter("image", image) :
                new ObjectParameter("image", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("updateEmployee", empIdParameter, empNameParameter, genderParameter, addressParameter, phoneParameter, dobParameter, emailParameter, identityNumberParameter, departmentIdParameter, imageParameter);
        }
    
        public virtual int updateFamily(Nullable<int> id, string familyId, string familyName, Nullable<int> numberMember)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var familyIdParameter = familyId != null ?
                new ObjectParameter("familyId", familyId) :
                new ObjectParameter("familyId", typeof(string));
    
            var familyNameParameter = familyName != null ?
                new ObjectParameter("familyName", familyName) :
                new ObjectParameter("familyName", typeof(string));
    
            var numberMemberParameter = numberMember.HasValue ?
                new ObjectParameter("numberMember", numberMember) :
                new ObjectParameter("numberMember", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("updateFamily", idParameter, familyIdParameter, familyNameParameter, numberMemberParameter);
        }
    
        public virtual int updateMember(Nullable<int> id, string memberId, string name, Nullable<bool> gender, string email, string identityNumber, string image, Nullable<System.DateTime> dob, string phone, Nullable<int> familyId)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            var memberIdParameter = memberId != null ?
                new ObjectParameter("memberId", memberId) :
                new ObjectParameter("memberId", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var genderParameter = gender.HasValue ?
                new ObjectParameter("gender", gender) :
                new ObjectParameter("gender", typeof(bool));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var identityNumberParameter = identityNumber != null ?
                new ObjectParameter("identityNumber", identityNumber) :
                new ObjectParameter("identityNumber", typeof(string));
    
            var imageParameter = image != null ?
                new ObjectParameter("image", image) :
                new ObjectParameter("image", typeof(string));
    
            var dobParameter = dob.HasValue ?
                new ObjectParameter("dob", dob) :
                new ObjectParameter("dob", typeof(System.DateTime));
    
            var phoneParameter = phone != null ?
                new ObjectParameter("phone", phone) :
                new ObjectParameter("phone", typeof(string));
    
            var familyIdParameter = familyId.HasValue ?
                new ObjectParameter("familyId", familyId) :
                new ObjectParameter("familyId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("updateMember", idParameter, memberIdParameter, nameParameter, genderParameter, emailParameter, identityNumberParameter, imageParameter, dobParameter, phoneParameter, familyIdParameter);
        }
    
        public virtual ObjectResult<searchApartment_Result> searchApartment(string apartId)
        {
            var apartIdParameter = apartId != null ?
                new ObjectParameter("apartId", apartId) :
                new ObjectParameter("apartId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<searchApartment_Result>("searchApartment", apartIdParameter);
        }
    
        public virtual ObjectResult<searchApart_Result> searchApart(string apartId)
        {
            var apartIdParameter = apartId != null ?
                new ObjectParameter("apartId", apartId) :
                new ObjectParameter("apartId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<searchApart_Result>("searchApart", apartIdParameter);
        }
    
        public virtual ObjectResult<searchApartById_Result> searchApartById(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<searchApartById_Result>("searchApartById", idParameter);
        }
    
        public virtual ObjectResult<searchFamilyById_Result> searchFamilyById(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<searchFamilyById_Result>("searchFamilyById", idParameter);
        }
    
        public virtual ObjectResult<searchFamilyByid1_Result> searchFamilyByid1(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("id", id) :
                new ObjectParameter("id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<searchFamilyByid1_Result>("searchFamilyByid1", idParameter);
        }
    
        public virtual int deleteContract(Nullable<int> contractId)
        {
            var contractIdParameter = contractId.HasValue ?
                new ObjectParameter("contractId", contractId) :
                new ObjectParameter("contractId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("deleteContract", contractIdParameter);
        }
    
        public virtual int deleteContractDetails(Nullable<int> contDetailId)
        {
            var contDetailIdParameter = contDetailId.HasValue ?
                new ObjectParameter("contDetailId", contDetailId) :
                new ObjectParameter("contDetailId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("deleteContractDetails", contDetailIdParameter);
        }
    
        public virtual ObjectResult<getContract_Result> getContract()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getContract_Result>("getContract");
        }
    
        public virtual int insertContract(string contractName, Nullable<int> familyId, Nullable<int> empId)
        {
            var contractNameParameter = contractName != null ?
                new ObjectParameter("contractName", contractName) :
                new ObjectParameter("contractName", typeof(string));
    
            var familyIdParameter = familyId.HasValue ?
                new ObjectParameter("familyId", familyId) :
                new ObjectParameter("familyId", typeof(int));
    
            var empIdParameter = empId.HasValue ?
                new ObjectParameter("empId", empId) :
                new ObjectParameter("empId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insertContract", contractNameParameter, familyIdParameter, empIdParameter);
        }
    
        public virtual int insertContractDetails(string limitation, Nullable<System.DateTime> signDay, string content, Nullable<int> contractId)
        {
            var limitationParameter = limitation != null ?
                new ObjectParameter("limitation", limitation) :
                new ObjectParameter("limitation", typeof(string));
    
            var signDayParameter = signDay.HasValue ?
                new ObjectParameter("signDay", signDay) :
                new ObjectParameter("signDay", typeof(System.DateTime));
    
            var contentParameter = content != null ?
                new ObjectParameter("content", content) :
                new ObjectParameter("content", typeof(string));
    
            var contractIdParameter = contractId.HasValue ?
                new ObjectParameter("contractId", contractId) :
                new ObjectParameter("contractId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insertContractDetails", limitationParameter, signDayParameter, contentParameter, contractIdParameter);
        }
    
        public virtual int updateContract(Nullable<int> contractId, string contractName, Nullable<int> familyId, Nullable<int> empId)
        {
            var contractIdParameter = contractId.HasValue ?
                new ObjectParameter("contractId", contractId) :
                new ObjectParameter("contractId", typeof(int));
    
            var contractNameParameter = contractName != null ?
                new ObjectParameter("contractName", contractName) :
                new ObjectParameter("contractName", typeof(string));
    
            var familyIdParameter = familyId.HasValue ?
                new ObjectParameter("familyId", familyId) :
                new ObjectParameter("familyId", typeof(int));
    
            var empIdParameter = empId.HasValue ?
                new ObjectParameter("empId", empId) :
                new ObjectParameter("empId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("updateContract", contractIdParameter, contractNameParameter, familyIdParameter, empIdParameter);
        }
    
        public virtual int updateContractDetails(Nullable<int> contDetailId, string limitation, Nullable<System.DateTime> signDay, string content, Nullable<int> contractId)
        {
            var contDetailIdParameter = contDetailId.HasValue ?
                new ObjectParameter("contDetailId", contDetailId) :
                new ObjectParameter("contDetailId", typeof(int));
    
            var limitationParameter = limitation != null ?
                new ObjectParameter("limitation", limitation) :
                new ObjectParameter("limitation", typeof(string));
    
            var signDayParameter = signDay.HasValue ?
                new ObjectParameter("signDay", signDay) :
                new ObjectParameter("signDay", typeof(System.DateTime));
    
            var contentParameter = content != null ?
                new ObjectParameter("content", content) :
                new ObjectParameter("content", typeof(string));
    
            var contractIdParameter = contractId.HasValue ?
                new ObjectParameter("contractId", contractId) :
                new ObjectParameter("contractId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("updateContractDetails", contDetailIdParameter, limitationParameter, signDayParameter, contentParameter, contractIdParameter);
        }
    
        public virtual ObjectResult<searchContractByName_Result> searchContractByName(string contractName)
        {
            var contractNameParameter = contractName != null ?
                new ObjectParameter("contractName", contractName) :
                new ObjectParameter("contractName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<searchContractByName_Result>("searchContractByName", contractNameParameter);
        }
    
        public virtual ObjectResult<searchContractDetailsById_Result> searchContractDetailsById(Nullable<int> contractId)
        {
            var contractIdParameter = contractId.HasValue ?
                new ObjectParameter("contractId", contractId) :
                new ObjectParameter("contractId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<searchContractDetailsById_Result>("searchContractDetailsById", contractIdParameter);
        }
    
        public virtual ObjectResult<getSerBill_Result> getSerBill()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<getSerBill_Result>("getSerBill");
        }
    
        public virtual ObjectResult<searchApartByIdOrApart_Result> searchApartByIdOrApart(string apartId, string familyId)
        {
            var apartIdParameter = apartId != null ?
                new ObjectParameter("apartId", apartId) :
                new ObjectParameter("apartId", typeof(string));
    
            var familyIdParameter = familyId != null ?
                new ObjectParameter("familyId", familyId) :
                new ObjectParameter("familyId", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<searchApartByIdOrApart_Result>("searchApartByIdOrApart", apartIdParameter, familyIdParameter);
        }
    }
}
