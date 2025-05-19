# Sistema de consultas para uma clínica médica

Desenvolvido utilizando C# e MySQL, o sistema consiste basicamente em um CRUD. Este repositório é responsável pela aba "Consultas" do projeto BeaMedicine. Acesse o repositório geral da [BeaMedicine](https://github.com/opedrvisk/SiteSistemaHospital) para mais informações.

![image](https://github.com/user-attachments/assets/96802c23-aa30-4ddc-9b50-f9f87dc65b58)

---

# Funcionalidades acerca do código

## MySQL

Para que o código funcione de maneira correta, é necessário criar um banco de dados no MySQL com essas tabelas.

![carbon (2)](https://github.com/user-attachments/assets/06eee334-0391-4ee9-b872-c6efbc6ac5a3)

Alguns inserts foram feitos através do próprio SQL, para melhor visualização do funcionamento do código.

![carbon](https://github.com/user-attachments/assets/1a7a63aa-3ac7-43a7-94ca-2201033a3f02)

Agora, toda a parte do banco de dados será continuado C#, através do MySqlClient.

---

## C#

Abaixo será mostrado os métodos e classes utilizadas.

### Conexão SQL

![image](https://github.com/user-attachments/assets/9e0840e5-3e5a-442f-ae5e-71faff0cdcb2)

### Pessoa - Classe base para Paciente e Medico. Define propriedades comuns como nome e CPF, além de métodos virtuais para salvar e mostrar informações.

![image](https://github.com/user-attachments/assets/80efcc8c-6b73-4237-8334-a26c6cbbde1e)

### Médico - Representa um médico da clínica. Permite cadastrar, listar, consultar por ID e deletar médicos. Armazena informações como nome, CPF e especialidade.

![medico](https://github.com/user-attachments/assets/97975e68-a8a4-454a-bf96-48267d20452f)

### Paciente - Representa um paciente da clínica. Permite cadastrar, listar, consultar por ID e deletar pacientes. Armazena informações como nome, CPF e convênio.

![paciente](https://github.com/user-attachments/assets/a2b85a40-a807-4818-bbd5-4d1f67cc1366)

### Recepcionista - Recepcionista gerencia os dados dos recepcionistas da clínica, permitindo operações de cadastro, consulta, listagem e exclusão desses funcionários no sistema.

![recepcionista](https://github.com/user-attachments/assets/3363e79b-7e6e-4423-8d74-18fba6aab35f)

### Consulta - Gerencia as consultas médicas. Permite criar (inserir), listar, consultar por ID e deletar consultas no banco de dados. Cada consulta está associada a um paciente e um médico, usando os respectivos IDs.

![consulta](https://github.com/user-attachments/assets/7e3cb3a7-67dd-490d-90c7-6a8d8c740d88)

---

# Funcionamento

Para demonstrar, utilizaremos dois exemplos.

### Inserir um paciente e consultá-lo no sistema.

![carbon (3)](https://github.com/user-attachments/assets/2312994e-b94d-4136-9514-6a709d4e168e)

### Marcar uma consulta com nosso paciente cadastrado e um médico já cadastrado no sistema, conferindo o ID dele antes.

![carbon (4)](https://github.com/user-attachments/assets/761995ab-c784-45de-b656-cdd39f5b9e09)

---

### Stack Utilizada

**Back-End**: C# e MySQL

---

## ESTE REPOSITÓRIO É UMA PARTE DO SISTEMA [BeaMedicine](https://github.com/opedrvisk/SiteSistemaHospital)
