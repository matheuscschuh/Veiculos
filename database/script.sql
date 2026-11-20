CREATE TABLE IF NOT EXISTS marcas (
	codigo SERIAL PRIMARY KEY,
	nome VARCHAR(50) NOT NULL UNIQUE CHECK (TRIM(nome) <> '')
);

CREATE TABLE IF NOT EXISTS veiculos (
	codigo SERIAL PRIMARY KEY,
	placa VARCHAR(15) NOT NULL UNIQUE CHECK (TRIM(placa) <> '' AND placa = UPPER(placa)),
	modelo VARCHAR(30) NOT NULL CHECK (TRIM(modelo) <> ''),
	ano INT NOT NULL,
	codigo_marca INT NOT NULL,
	tipo VARCHAR(30) NOT NULL CHECK (tipo IN ('Carro', 'Moto')),
	possui_ar_condicionado BOOLEAN,
	possui_bau BOOLEAN,

	CONSTRAINT fk_marca
		FOREIGN KEY (codigo_marca) REFERENCES marcas(codigo) ON DELETE RESTRICT,

	CONSTRAINT ano_valido
		CHECK (ano >= 1950 AND ano <= EXTRACT(YEAR FROM CURRENT_DATE)),

	CONSTRAINT verificacao_atributos_veiculo 
		CHECK (
        (tipo = 'Carro' AND possui_ar_condicionado IS NOT NULL AND possui_bau IS NULL)
        OR
        (tipo = 'Moto' AND possui_bau IS NOT NULL AND possui_ar_condicionado IS NULL)
    )
	
);

CREATE TABLE IF NOT EXISTS logtransacao (
	id SERIAL PRIMARY KEY,
	tabela TEXT NOT NULL,
    operacao TEXT NOT NULL,
    data_hora TIMESTAMP DEFAULT CURRENT_TIMESTAMP NOT NULL
);

CREATE OR REPLACE FUNCTION log_transacoes()
RETURNS TRIGGER AS $$
BEGIN
    INSERT INTO logtransacao (tabela, operacao)
    VALUES (TG_TABLE_NAME, TG_OP);

	RETURN NULL;
END;
$$ LANGUAGE plpgsql;

CREATE OR REPLACE TRIGGER log_veiculos
AFTER INSERT OR UPDATE OR DELETE ON veiculos
FOR EACH ROW
EXECUTE FUNCTION log_transacoes();