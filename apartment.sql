create database Apartment
go
use Apartment
go
SELECT * FROM tblPermission
SELECT * FROM tblUser
SELECT * FROM tblPerRelationship

go

create table tblPermission(
	permissionId int identity(1,1) PRIMARY KEY,
	permissionName nvarchar(100) unique not null,
	permissionAccess text
)

go

INSERT INTO tblPermission VALUES ('ADMIN','All')

go

create table tblUser(
	userId int identity(1,1) PRIMARY KEY,
	uuid nvarchar(100) unique not null,
	pwd nvarchar(100),
	status bit
)

go

INSERT INTO tblUser VALUES ('admin','123456',1)

go

CREATE TABLE tblPerRelationship(
	idRel int identity(1,1) PRIMARY KEY,
	idUserRel int,
	idPerRel int,
	foreign key(idUserRel) references tblUser(userId),
	foreign key(idPerRel) references tblPermission(permissionId),
)
go

INSERT INTO tblPerRelationship VALUES (1,1)

go

create table tblFamily(
	id int identity(1,1) PRIMARY KEY,
	familyId varchar(20) unique,
	familyName nvarchar(100),
	numberMember int
)
go
INSERT INTO tblFamily Values('P301',N'Nguyễn Văn Tuất',1)

go
create table tblMember(
	id int identity(1,1) PRIMARY KEY,
	memberId nvarchar(5) not null,
	name nvarchar(50) not null,
	gender bit,
	email nvarchar(200) unique,
	identityNumber varchar(20) unique,
	image text,
	dob Date,
	phone varchar(12),
	familyId int,
	Foreign Key (familyId) references tblFamily(id)
)
go
INSERT INTO tblMember Values('301-1',N'Nguyễn Văn Tuất',1,'tuat@gmail.com','2134567895',N'','1990-01-01','2134567894',1)

go
create table tblApartment(
	id int identity(1,1) PRIMARY KEY,
	apartId varchar(5) not null unique,
	price float,
	area float,
	note nvarchar(100),
	image text,
	status bit,
	familyId int null,
	foreign key(familyId) references tblFamily(id)
)
go
INSERT INTO tblApartment Values('301',17000000,100,'tuat@gmail.com',N'',1,1)

go
create table tblEmployee(
	empId int identity(1,1) PRIMARY KEY,
	empName nvarchar(100),
	gender bit,
	address nvarchar(100),
	phone varchar(12),
	dob date,
	email varchar(200),
	identityNumber varchar(20) unique,
	departmentId int,
	image text
)
go
INSERT INTO tblEmployee VALUES ('Nguyen Van A', 1, 'Ha Noi', '0987654321', '1990-01-01', 'a@gmail.com', '0192837465', 1, N'')
go
create table tblContract(
	contractId int identity(1,1) PRIMARY KEY,
	contractName nvarchar(100) unique,
	familyId int,
	empId int,
	foreign key (familyId) references tblApartment(id),
	foreign key (empId) references tblEmployee(empId),
)
go
create table tblContractDetail(
	contDetailId int identity(1,1) PRIMARY KEY,
	limitation nvarchar(50),
	signDay date,
	content nvarchar(1000),
	contractId int,
	Foreign Key (contractId) references  tblContract(contractId)
)
go

create table tblService(
	id int identity(1,1) PRIMARY KEY,
	serId varchar(5) unique not null,
	serName nvarchar(200),
	price float
)
go

Insert into tblService values 
('DV001',N'Hóa đơn dịch vụ',1200),
('VS001',N'Hóa đơn vệ sinh',17000)

go
create table tblServiceBill(
	id varchar(10) PRIMARY KEY,
	serBillName nvarchar(200),
	note nvarchar(200),
	total float,
	datePrint datetime,
	empId int,
	apartId int,
	serId int,
	foreign key (apartId) references tblApartment(id),
	foreign key (empId) references tblEmployee(empId),
	foreign key (serId) references tblService(id)
)

/* CREATE PROCEDURE */
select * from tblUser
select * from tblPermission
select * from tblPerRelationship
-- TABLE PERMISSION
DROP PROC getPermission
GO
CREATE PROC getPermission
	as
SELECT * FROM tblPermission
GO

-- TABLE USER 
DROP PROC getUser
GO
CREATE PROC getUser
	as
SELECT * FROM tblUser
go
DROP PROC getUserLogin
go
CREATE PROC getUserLogin
@uuid nvarchar(100),
@pwd nvarchar(100)
	as
SELECT * FROM tblUser WHERE uuid = @uuid AND pwd = @pwd

go

-- TABLE EMPLOYEE
DROP PROC getEmployee
GO
CREATE PROC getEmployee
	as
SELECT * FROM tblEmployee
go

DROP PROC getMaxIdEmp
GO
CREATE PROC getMaxIdEmp
	as
SELECT TOP 1 empId FROM tblEmployee ORDER BY empId DESC
go

DROP PROC insertEmployee
GO
CREATE PROC insertEmployee
@empName nvarchar(100),
@gender bit,
@address nvarchar(100),
@phone varchar(12),
@dob date,
@email varchar(200),
@identityNumber varchar(20),
@departmentId int,
@image text
	AS
INSERT INTO tblEmployee VALUES (@empName,@gender,@address,@phone,@dob,@email,@identityNumber,@departmentId,@image)
GO 

DROP PROC updateEmployee
GO
CREATE PROC updateEmployee
@empId int,
@empName nvarchar(100),
@gender bit,
@address nvarchar(100),
@phone varchar(12),
@dob date,
@email varchar(200),
@identityNumber varchar(20),
@departmentId int,
@image text
	AS
UPDATE tblEmployee SET empName = @empName,gender = @gender, address = @address,phone = @phone,dob = @dob,email = @email,identityNumber = @identityNumber,departmentId = @departmentId,image = @image WHERE empId = @empId
GO 

DROP PROC deleteEmployee
GO
CREATE PROC deleteEmployee
@empId int
	AS
DELETE FROM tblEmployee WHERE empId = @empId
GO



-- TABLE APARTMENT
DROP PROC getAparment
GO
CREATE PROC getAparment
	as
SELECT * FROM tblApartment
go

DROP PROC insertApartment
GO
CREATE PROC insertApartment
@apartId varchar(5),
@price float,
@area float,
@note nvarchar(100),
@image text,
@status bit,
@familyId int
	as
INSERT INTO tblApartment VALUES (@apartId, @price, @area, @note, @image, @status, @familyId)
GO
DROP PROC updateApartment
GO
CREATE PROC updateApartment
@id int,
@apartId varchar(5),
@price float,
@area float,
@note nvarchar(100),
@image text,
@status bit,
@familyId int
	as
UPDATE tblApartment SET apartId = @apartId, price= @price,area= @area, note = @note,image= @image,status= @status,familyId= @familyId WHERE id = @id
GO
DROP PROC deleteApartment
GO
CREATE PROC deleteApartment
@id int
	as
DELETE FROM tblApartment WHERE id = @id
GO

DROP PROC searchApartById
GO
CREATE PROC searchApartById
@id int
	as
SELECT * FROM tblApartment WHERE id = @id
GO
DROP PROC searchApart
GO
CREATE PROC searchApart
@apartId varchar(5)
	as
SELECT * FROM tblApartment WHERE apartId like '%' + @apartId + '%'
GO

CREATE PROC searchApartByIdOrApart
@apartId varchar(5),
@familyId varchar(20)
	as
SELECT * FROM tblApartment WHERE apartId like '%' + @apartId + '%' or familyId like '%' + @familyId + '%'
GO


-- TABLE FAMILY && MEMBER
DROP PROC getFamily
GO
CREATE PROC getFamily
	as
SELECT * FROM tblFamily
go

DROP PROC insertFamily
GO
CREATE PROC insertFamily
@familyId varchar(20),
@familyName nvarchar(100),
@numberMember int
	as
INSERT INTO tblFamily VALUES (@familyId, @familyName, @numberMember)
go
DROP PROC updateFamily
go
CREATE PROC updateFamily
@id int,
@familyId varchar(20),
@familyName nvarchar(100),
@numberMember int
	as
UPDATE tblFamily SET familyId = @familyId, familyName = @familyName, numberMember = @numberMember WHERE id = @id
go
DROP PROC deleteFamily
go
CREATE PROC deleteFamily
@id int
	as
DELETE FROM tblFamily WHERE id = @id
go

DROP PROC searchFamily
GO
CREATE PROC searchFamily
@id int
	as
SELECT * FROM tblMember WHERE familyId = @id
GO
DROP PROC searchFamilyByid
GO
CREATE PROC searchFamilyByid
@id int
	as
SELECT * FROM tblFamily WHERE id = @id
GO

DROP PROC getMember
GO
CREATE PROC getMember
	as
SELECT * FROM tblMember
go

DROP PROC insertMember
GO
CREATE PROC insertMember
@memberId nvarchar(5) ,
@name nvarchar(50) ,
@gender bit,
@email nvarchar(200) ,
@identityNumber varchar(20) ,
@image text,
@dob Date,
@phone varchar(12),
@familyId int
	as
INSERT INTO tblMember VALUES (@memberId, @name, @gender, @email, @identityNumber, @image, @dob, @phone, @familyId)
GO

DROP PROC updateMember
GO
CREATE PROC updateMember
@id int,
@memberId nvarchar(5) ,
@name nvarchar(50) ,
@gender bit,
@email nvarchar(200) ,
@identityNumber varchar(20) ,
@image text,
@dob Date,
@phone varchar(12),
@familyId int
	as
UPDATE tblMember SET memberId=@memberId, name=@name, gender=@gender, email=@email, identityNumber= @identityNumber, image=@image, dob=@dob, phone=@phone, familyId= @familyId WHERE id = @id
GO

DROP PROC deleteMember
GO
CREATE PROC deleteMember
@id int
	as
DELETE FROM tblMember WHERE id = @id
GO


-- TABLE CONTRACT && CONTRACT DETAILs
DROP PROC getContract
GO
CREATE PROC getContract
	as
SELECT c.ContractId, c.ContractName, c.familyId, c.empId, d.limitation, d.signDay, d.content FROM tblContract c INNER JOIN tblContractDetail d ON c.contractId = d.contractId
GO

DROP PROC insertContract
GO
CREATE PROC insertContract
@contractName nvarchar(100),
@familyId int,
@empId int
	as
INSERT INTO tblContract VALUES (@contractName, @familyId, @empId)
GO
DROP PROC updateContract
GO
CREATE PROC updateContract
@contractId int,
@contractName nvarchar(100),
@familyId int,
@empId int
	as
UPDATE tblContract SET contractName=@contractName, familyId=@familyId, empId=@empId WHERE contractId = @contractId
GO
DROP PROC deleteContract
GO
CREATE PROC deleteContract
@contractId int
	as
DELETE FROM tblContract WHERE contractId = @contractId

DROP PROC searchContractByName
GO
CREATE PROC searchContractByName
@contractName nvarchar(100)
	as
SELECT * FROM tblContract WHERE contractName = @contractName
GO

-- CONTRACT DETAILS

DROP PROC insertContractDetails
GO
CREATE PROC insertContractDetails
@limitation nvarchar(50),
@signDay date,
@content text,
@contractId int
	as
INSERT INTO tblContractDetail VALUES (@limitation, @signDay, @content, @contractId)
GO
DROP PROC updateContractDetails
GO
CREATE PROC updateContractDetails
@contDetailId int,
@limitation nvarchar(50),
@signDay date,
@content text,
@contractId int
	as
UPDATE tblContractDetail SET limitation=@limitation, signDay=@signDay, content=@content, contractId=@contractId WHERE contDetailId=@contDetailId
GO
DROP PROC deleteContractDetails
GO
CREATE PROC deleteContractDetails
@contDetailId int
	as
DELETE FROM tblContractDetail WHERE contDetailId = @contDetailId

DROP PROC searchContractDetailsById
GO
CREATE PROC searchContractDetailsById
@contractId int
	as
SELECT * FROM tblContractDetail WHERE contractId = @contractId
GO


-- TABLE SERVICE && SERVICE BILL
DROP PROC getSerBill
GO
CREATE PROC getSerBill
	as
SELECT * FROM tblServiceBill
GO

