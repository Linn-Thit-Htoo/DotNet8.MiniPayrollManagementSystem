USE [MiniPayrollManagementSystem]
GO
/****** Object:  Table [dbo].[Tbl_Employee]    Script Date: 6/2/2024 12:41:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Employee](
	[EmployeeId] [bigint] IDENTITY(1,1) NOT NULL,
	[EmployeeCode] [nvarchar](50) NOT NULL,
	[EmployeeName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[PhoneNumber] [nvarchar](50) NOT NULL,
	[HireDate] [nvarchar](50) NOT NULL,
	[Position] [nvarchar](50) NOT NULL,
	[Salary] [decimal](18, 2) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Tbl_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tbl_Payroll]    Script Date: 6/2/2024 12:41:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tbl_Payroll](
	[PId] [nvarchar](50) NOT NULL,
	[EmployeeName] [nvarchar](50) NOT NULL,
	[PayDate] [nvarchar](50) NOT NULL,
	[GrossPay] [decimal](18, 2) NOT NULL,
	[NetPay] [decimal](18, 2) NOT NULL,
	[DeductionAmount] [decimal](18, 2) NULL,
	[BonusAmount] [decimal](18, 2) NULL,
	[TaxAmount] [decimal](18, 2) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Tbl_Payroll] PRIMARY KEY CLUSTERED 
(
	[PId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[Sp_FilterPayrollByEmployeeCode]    Script Date: 6/2/2024 12:41:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Sp_FilterPayrollByEmployeeCode] 
    @EmployeeCode NVARCHAR(50)
AS
BEGIN
	SELECT PId, Tbl_Payroll.EmployeeName, PayDate, GrossPay, NetPay, Tbl_Payroll.IsActive
	DeductionAmount, BonusAmount, TaxAmount, EmployeeCode
	FROM Tbl_Payroll
	INNER JOIN Tbl_Employee ON Tbl_Employee.EmployeeCode = @EmployeeCode
	WHERE Tbl_Payroll.IsActive = '1'
	ORDER BY PId DESC
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_FilterPayrollByFromDateToDateWithEmployeeCode]    Script Date: 6/2/2024 12:41:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Sp_FilterPayrollByFromDateToDateWithEmployeeCode] 
    @FromDate NVARCHAR(50), 
    @ToDate NVARCHAR(50),
    @EmployeeCode NVARCHAR(50)
AS
BEGIN
	SELECT PId, Tbl_Payroll.EmployeeName, PayDate, GrossPay, NetPay, Tbl_Payroll.IsActive,
	DeductionAmount, BonusAmount, TaxAmount, EmployeeCode
	FROM Tbl_Payroll
	INNER JOIN Tbl_Employee ON Tbl_Employee.EmployeeCode = @EmployeeCode
	WHERE PayDate >= @FromDate AND PayDate <= @ToDate AND Tbl_Payroll.IsActive = '1'
	ORDER BY PId DESC
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_FilterPayrollByFromDateWithEmployeeCode]    Script Date: 6/2/2024 12:41:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Sp_FilterPayrollByFromDateWithEmployeeCode] 
    @FromDate NVARCHAR(50), 
    @EmployeeCode NVARCHAR(50)
AS
BEGIN
	SELECT PId, Tbl_Payroll.EmployeeName, PayDate, GrossPay, NetPay, Tbl_Payroll.IsActive
	DeductionAmount, BonusAmount, TaxAmount, EmployeeCode
	FROM Tbl_Payroll
	INNER JOIN Tbl_Employee ON Tbl_Employee.EmployeeCode = @EmployeeCode
	WHERE PayDate >= @FromDate AND Tbl_Payroll.IsActive = '1'
	ORDER BY PId DESC
END
GO
/****** Object:  StoredProcedure [dbo].[Sp_FilterPayrollByToDateWithEmployeeCode]    Script Date: 6/2/2024 12:41:32 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Sp_FilterPayrollByToDateWithEmployeeCode] 
    @ToDate NVARCHAR(50), 
    @EmployeeCode NVARCHAR(50)
AS
BEGIN
	SELECT PId, Tbl_Payroll.EmployeeName, PayDate, GrossPay, NetPay, Tbl_Payroll.IsActive
	DeductionAmount, BonusAmount, TaxAmount, EmployeeCode
	FROM Tbl_Payroll
	INNER JOIN Tbl_Employee ON Tbl_Employee.EmployeeCode = @EmployeeCode
	WHERE PayDate <= @ToDate AND Tbl_Payroll.IsActive = '1'
	ORDER BY PId DESC
END
GO
