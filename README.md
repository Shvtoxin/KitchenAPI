Описание предметной области
---
Автоматизация процесса учета рабочего времени сотрудников.

Автор
---
Шатохин Александр студент группы ИП 20-3

Схема моделей
---
```mermaid
    classDiagram
    Staff <.. Post
    TurnOut <.. Cuisine
    TurnOut <.. Stimulation
    TurnOut <.. TypeOfTurnout
    TurnOut <.. Staff
    Cuisine .. TypeOfKitchen
    BaseAuditEntity --|> Cuisine
    BaseAuditEntity --|> Post
    BaseAuditEntity --|> Stimulation
    BaseAuditEntity --|> TypeOfTurnout
    BaseAuditEntity --|> TurnOut
    BaseAuditEntity --|> Staff
    IEntity ..|> BaseAuditEntity
    IEntityAuditCreated ..|> BaseAuditEntity
    IEntityAuditDeleted ..|> BaseAuditEntity
    IEntityAuditUpdated ..|> BaseAuditEntity
    IEntityWithId ..|> BaseAuditEntity
    class IEntity{
        <<interface>>
    }
    class IEntityAuditCreated{
        <<interface>>
        +DateTimeOffset CreatedAt
        +string CreatedBy
    }
    class IEntityAuditDeleted{
        <<interface>>
        +DateTimeOffset? DeletedAt
    }
    class IEntityAuditUpdated{
        <<interface>>
        +DateTimeOffset UpdatedAt
        +string UpdatedBy
    }
    class IEntityWithId{
        <<interface>>
        +Guid Id
    }        
    class Cuisine{
        +string Title
        +string Address
        +string? Description
        +TypeOfKitchen Type
        +string OpeningTime
        +string ClosingTime
    }
    class Post{
        +string Title
        +decimal PayPerHour
    }
    class Stimulation {
        +string Title
        +string Description
    }
    class TypeOfTurnout {
        +string Title
        +string? Description
    }
    class Staff {
        +string LastName
        +string FirstName
        +string Patronymic
        +int Age
        +Guid PostId
        +string Email
        +DateTimeOffset DateOfHiring
    }
    class TurnOut {
        +Guid CuisineId 
        +Guid StaffId
        +Guid TypeOfTurnoutId
        +Guid? StimlationId
        +DateTimeOffset OpeningTime
        +DateTimeOffset? CloseTime
    }
    class TypeOfKitchen {
        <<enumeration>>
        DarkKitchen(Темная кухня)
        MiniFormat(Мини формат)
        Sushipoint(Суши-поинт)
    }
    class BaseAuditEntity {
        <<Abstract>>        
    }
```
Пример реального бизнес сценария
---
![03055905-5051-4a1d-bce1-b6420a7c2b74](https://github.com/Shvtoxin/KitchenAPI/assets/95116781/d3e17c78-2588-41bf-9fcd-a606d14b064f)

SQL скрипт
---
```
```
