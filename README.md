# WEB API - CRUD Pacientes

- Projeto criado utilizando Context para representar o contexto do banco de dados e gerenciar sua conexão, Migrations para representar e gerenciar as alterações no esquema do banco de dados, Padrão Repository responsável por encapsular a lógica de acesso aos dados e fornecer métodos para realizar operações de CRUD no banco de dados, e a biblioteca AutoMapper utilizada para mapear as entidades e DTOs.
  
- Banco de dados utilizado: PostgreSQL

- Vídeo demonstrativo das funcionalidades: https://youtu.be/WllYcBYgsZE 

## Endpoints

POST /api/Patient/CreatePatient/

GET /api/Patient/GetPatient/{name}

PATCH /api/Patient/Inactivatepatient/{id}

PUT /api/Patient/UpdatePatient/{id}

DELETE /api/Patient/DeletePatient/{id}
