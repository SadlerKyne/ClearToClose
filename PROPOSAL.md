# Project Proposal: Clear to Close

## Project Overview

Clear to Close is a personal finance web application that helps someone working toward mortgage qualification track their debt-to-income (DTI) ratio, stay on top of their bills, and understand where their money is going. Lenders evaluate DTI as a core qualification metric, but most people have no easy way to see their own number, watch it improve over time, or connect it to the everyday bills and purchases that drive it. Clear to Close solves that by giving users one place to enter their income and debts, see their current DTI against a goal they set for themselves, track recurring bills against their paychecks, and log purchases by category.

The target users are individuals actively preparing to qualify for or close on a mortgage — first-time homebuyers, people refinancing, or anyone who wants to lower their DTI before applying for a loan. Unlike a full budgeting suite or a lender-facing loan origination system, Clear to Close is intentionally narrow: it exists to answer one question ("How close am I to a DTI a lender will accept, and what's in my way?") and to support the daily habits (paying bills on time, watching discretionary spending) that get a user there.

What makes this idea valuable is the direct link between an abstract lending metric (DTI) and the concrete, everyday financial actions a user already needs to track. Instead of a generic budgeting app, every feature in Clear to Close ties back to the same goal: getting and staying "clear to close."

## Project Scope

**What's IN:**
- User registration and login (per-user private financial data)
- DTI calculator based on user-entered income and debts
- User-set goal DTI with progress tracking over time
- Recurring bill and paycheck tracking, with paid/unpaid status per pay period
- Purchase logging with user-defined spending categories
- Category-level spending summaries
- A dashboard summarizing DTI status, bill status, and recent spending in one view

**What's OUT (for this semester):**
- Automatic bank/transaction import (e.g., Plaid or similar API integrations)
- Multi-user shared households or joint accounts
- Native mobile apps (the app will be a responsive web app instead)
- Automated bill payment or bill-pay integrations
- Credit score tracking or credit bureau integration
- Predictive/AI-driven financial forecasting or recommendations

Keeping the scope narrow means the core DTI/bills/spending loop will be fully functional and polished rather than spreading effort across many partially built features.

## App Features

1. Users can create an account and log in.
2. Users can enter their monthly income and existing debts to calculate their current DTI.
3. Users can set a goal DTI and see their progress toward it over time.
4. Users can add recurring bills and expected paycheck deposits.
5. Users can mark each bill as paid or unpaid for the current pay period.
6. Users can log individual purchases and assign them to a spending category.
7. Users can view spending totals broken down by category over a selected time period.
8. Users can view a dashboard summarizing their DTI status, upcoming/unpaid bills, and recent spending at a glance.

Example user story: "As someone preparing to buy a home, I want to see my DTI update as I pay down debts so I know how close I am to qualifying."

Each of these features is tracked as a card on the project's Trello board (linked below).

## Technical Considerations

- **Data Storage:** A relational database (SQLite/SQL Server via Entity Framework Core) storing Users, Debts, Bills, Paychecks, Purchases, Spending Categories, and DTI Goals.
- **User Accounts:** Yes — ASP.NET Core Identity integrated with Blazor, so all financial data is scoped to the logged-in user.
- **External Services:** None required for the MVP; all calculations (DTI, category totals) are done in-app from user-entered data.
- **Device Compatibility:** The Blazor UI will use responsive layout (Bootstrap) so it works on desktop, tablet, and mobile browsers without a separate native app.
- **Basic Security:** Passwords hashed via ASP.NET Core Identity, authorization checks so a user can only read/write their own records, and HTTPS enforced in all environments.

## Project Links

- **GitHub Repository:** https://github.com/SadlerKyne/ClearToClose (public)
- **Trello Board:** https://trello.com/b/5CWMX3Sq/my-trello-board
