# 📄 Documentação – Rotas de Associados

Este documento descreve os endpoints disponíveis no controller `AssociadosController`, incluindo métodos HTTP, permissões necessárias, parâmetros e possíveis respostas.

---

## 🔹 Base do Controller

- **Rota base:** `/api/associados` *(herdada de `BaseApiController`)*  
- **Requisitos gerais:**  
  - Autenticação via JWT
  - Autorização com atributos `ShouldHavePermission`
  - Todas as respostas retornam um objeto de resposta (`response`) com propriedade `IsSuccessful`.

---

### 1. **Criar Associado**

- **Método:** `POST`
- **Endpoint:** `/add`
- **Permissões:**  
  - Ação: `AssociationAction.Create`
  - Feature: `AssociationFeature.Associados`
- **Corpo da requisição:**  
  ```csharp
  CreateAssociadoRequest createAssociado
  ```
- **Retorno:**  
  - `200 OK` – quando `response.IsSuccessful`  
  - `400 Bad Request` – caso contrário

---

### 2. **Atualizar Associado**

- **Método:** `PUT`
- **Endpoint:** `/update/{associadoId}`
- **Permissões:**  
  - Ação: `AssociationAction.Update`
  - Feature: `AssociationFeature.Associados`
- **Parâmetros de rota:**  
  - `associadoId` – string
- **Corpo da requisição:**  
  ```csharp
  UpdateAssociadoRequest updateAssociado
  ```
- **Retorno:**  
  - `200 OK` – quando `response.IsSuccessful`
  - `404 Not Found` – se não encontrado

---

### 3. **Excluir Associado**

- **Método:** `DELETE`
- **Endpoint:** `/{associadoId}`
- **Permissões:**  
  - Ação: `AssociationAction.Delete`
  - Feature: `AssociationFeature.Associados`
- **Parâmetros de rota:**  
  - `associadoId` – string
- **Retorno:**  
  - `200 OK` – quando `response.IsSuccessful`
  - `404 Not Found` – se não encontrado

---

### 4. **Obter Associado por ID**

- **Método:** `GET`
- **Endpoint:** `/{associadoId}`
- **Permissões:**  
  - Ação: `AssociationAction.Read`
  - Feature: `AssociationFeature.Associados`
- **Parâmetros de rota:**  
  - `associadoId` – string
- **Retorno:**  
  - `200 OK` – quando `response.IsSuccessful`
  - `404 Not Found` – se não encontrado

---

### 5. **Listar Todos os Associados**

- **Método:** `GET`
- **Endpoint:** `/all`
- **Permissões:**  
  - Ação: `AssociationAction.Read`
  - Feature: `AssociationFeature.Associados`
- **Retorno:**  
  - `200 OK` – quando `response.IsSuccessful`
  - `404 Not Found` – se não encontrado

---

> 💡 **Observação:**  
Os comandos e queries utilizados no controller (`CreateAssociadoCommand`, `UpdateAssociadoCommand`, etc.) são definidos no projeto `Application.Features.Associados`.  
A validação de permissões utiliza constantes de `BabaPlayShared.Library.Constants`.

---

Essa documentação pode ser copiada para um arquivo `.md` no repositório ou integrada em um gerador de API.  
Se precisar de mais informações (ex.: exemplos de payloads ou schema dos requests), posso ajudar também!