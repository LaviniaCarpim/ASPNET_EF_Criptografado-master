CREATE TABLE RegistroProgresso (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    NomePaciente VARCHAR(100) NOT NULL,
    Doenca VARCHAR(50) NOT NULL,
    NivelDoenca VARCHAR(50) NOT NULL,
    DataRegistro DATETIME NOT NULL,
    ObservacoesCuidador VARCHAR(MAX)
);

SELECT * FROM RegistroProgresso;