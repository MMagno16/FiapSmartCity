use FIAPONSmartCity
CREATE TABLE PESSOA (
      IDPESSOA    int identity(1,1)        PRIMARY KEY,
      NOME VARCHAR(250)  NOT NULL,
      PHONE CHAR(11)
    );