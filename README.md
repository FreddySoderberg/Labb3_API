
# Labb3_API

Created a DB through Entity Framework, code-first, with 2 mapping tables looking like; 
Person(model) -> PersonInterest(mapping-table) -> Interest(model) -> InterestLink(mapping-table) -> Link(model)


## Acknowledgements //Creds where it's due.

 - [Awesome Readme Templates](https://awesomeopensource.com/project/elangosundar/awesome-README-templates)
 - [Awesome README](https://github.com/matiassingers/awesome-readme)
 - [How to write a Good readme](https://bulldogjob.com/news/449-how-to-write-a-good-readme-for-your-github-project)


## API Reference

#### Get all person in Database

```http
  GET /api/person
```

#### Get persons interests by choosing personId

```http
  GET /api/person/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Required**. Gets all the interests connected to the person by Id |

#### Gets all links of associated to person through PersonId

```http
  GET /api/person/link/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Required**. Gets all links associated to person through interests |

#### Adds new interest to person through id's

```http
  POST /api/person/${personId}/${interestId}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `personId`      | `int` | **Required**. Person who you want to add a interest to |
| `interestId`      | `int` | **Required**. Choose interest by id to connect to person |

#### Adds a new link to choosen interest by providing InterestId and NewLink

```http
  POST /api/person/${interestId}/${linkToAdd}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `interestId`      | `int` | **Required**. Id of interest, to connect interest to link |
| `linkToAdd`      | `string` | **Required**. String of new link to add to interest |


#### Delete person by Id

```http
  DELTE /api/person/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Required**. Id of person you want to delete |

#### Update person by id

```http
  PUT /api/person/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `int` | **Required**. Id of person you'd like to update |


