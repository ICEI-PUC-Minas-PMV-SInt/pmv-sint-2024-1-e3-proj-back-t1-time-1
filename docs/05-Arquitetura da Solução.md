# Arquitetura da Solução

<span style="color:red">Pré-requisitos: <a href="3-Projeto de Interface.md"> Projeto de Interface</a></span>

Definição de como o software é estruturado em termos dos componentes que fazem parte da solução.

## Diagrama de Classes

```mermaid
classDiagram
  Category "1" -- "1" Supplier
  Category "1..*" -- "*" Medicine
  Supplier "1" -- "1" Location
  Medicine "1..*" -- "*" Order
  Order "*" -- "1" Client
  Client "*" -- "1" Location

  class Category{
    -int Id
    -string Name
    +Category(int id, string name)
    +setId(int id)
    +getId() int
    +setName(string name)
    +getName() string
  }

  class Supplier{
    -int Id
    -string Name
    -Location Location
    +Supplier(int id, string name, Location location)
    +setId(int id)
    +getId() int
    +setName(string name)
    +getName() string
    +setLocation(Location location)
    +getLocation() Location
  }

  class Medicine{
    -int Id
    -Category Category
    -Supplier Supplier
    -int Quantity
    -float Price
    +Medicine(string id, Category category, Supplier supplier, int quantity, float price)
    +setId(int id)
    +getId() int
    +setSupplier(Supplier supplier)
    +getSupplier() Supplier
    +setCategory(Category category)
    +getCategory() Category
  }

  class Order{
    -int Id
    -DateTime Date
    -List~Medicine~ Medicine
    -Client Client
    +Order(int id, DateTime date, List~Medicine~ medicine, Client client)
    +setId(int id)
    +getId() int
    +setDate(DateTime date)
    +getDate() DateTime
    +setMedicines(List~Medicine~ medicines)
    +getMedicines() List~Medicines~
    +setClient(Client client)
    +getClient() Client
  }

  class Client{
    -int Cpf
    -string Name
    -int Phone
    -Location Location
    +Client(int cpf, string name, string address, int phone, Location location)
    +setCpf(int cpf)
    +getCpf() int
    +setName(string name)
    +getName() string
    +setPhone(int phone)
    +getPhone() int
    +setLocation(Location location)
    +getLocation() Location
  }

  class Location{
    -int Id
    -string Name
    +Location(int id, string name)
    +setId(int id)
    +getId() int
    +setName(string name)
    +getName() string
  }
```

Acima está um protótipo do diagrama de classes e seu esquema relacional. Note que todo o esquema é passível de alterações a medida que o projeto for desenvolvido!

- `Category`: Categoria do produto
- `Supplier`: Fornecedor do produto
- `Medicine`: O produto em si (medicamento, entre outros)
- `Order`: O pedido de um produto
- `Client`: Cliente registrado com nome e endereço
- `Location`: Usado em `Client` e `Supplier`, para identificação em comum de localizações
