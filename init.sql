IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'ClienteApi')
BEGIN
    CREATE DATABASE ClienteApi;
END

USE ClienteApi;

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Clientes')
BEGIN
    CREATE TABLE Clientes
    (
        Id UNIQUEIDENTIFIER PRIMARY KEY,
        NomeCompleto NVARCHAR(255) NOT NULL,
        EnderecoId UNIQUEIDENTIFIER,
        Telefone NVARCHAR(15),
        EmailPrincipal NVARCHAR(255),
        Cpf NVARCHAR(15) NOT NULL,
        Active BIT NOT NULL,
        CONSTRAINT FK_Endereco FOREIGN KEY (EnderecoId) REFERENCES Enderecos(Id)
    );
END

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Enderecos')
BEGIN
    CREATE TABLE Enderecos
    (
        Id UNIQUEIDENTIFIER PRIMARY KEY,
        Logradouro NVARCHAR(255) NOT NULL,
        Numero NVARCHAR(10) NOT NULL,
        Complemento NVARCHAR(100),
        Bairro NVARCHAR(100) NOT NULL,
        Cidade NVARCHAR(100) NOT NULL,
        Estado NVARCHAR(2) NOT NULL,
        Cep NVARCHAR(10) NOT NULL,
        ClienteId UNIQUEIDENTIFIER,
        CONSTRAINT FK_Cliente FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
    );
END

IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'EmailSecundarios')
BEGIN
    CREATE TABLE EmailSecundarios
    (
        Id UNIQUEIDENTIFIER PRIMARY KEY,
        EnderecoEmail NVARCHAR(255) NOT NULL,
        ClienteId UNIQUEIDENTIFIER,
        CONSTRAINT FK_Cliente_Email FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
    );
END
