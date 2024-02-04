# Project: Financial Goal Manager

## Technologies and practices
- AspNet.Core( .NET 7 )
- Clean Architecture
- MediatR
- Transactions
- IUnitOfWork
- Entity Framework Core
- CQRS
- Padrao Repository
- Validation of request in API (Fluent Validation)
- Unit Test (NUnit)

#### Develop a system (API or Full-Stack) for managing financial objectives, based on Nubank boxes.

1. Cash Management (Registration, Update, Removal, Listing, Details)
   - Validate data.
   - Create an endpoint that allows you to simulate the evolution of Cash, based on the amount of monthly contributions and income (PLUS)
   - Create an endpoint that allows you to upload a goal/box cover image (PLUS) file
   - Create a property for the total value of the Box always calculated when registering new transactions, instead of always adding everything up when searching for details (PLUS) Tip: use transaction
2. Transaction Management (Registration, Removal, Listing, Details)
   - Validate data.
3. Reports
   - Generate a report on the evolution of Boxes (PLUS)

#### Business rules

- Transaction must be made with up to two decimal places of precision, and cannot be negative
- Type: Deposit / Withdraw
