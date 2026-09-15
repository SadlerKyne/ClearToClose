# Clear to Close

A .NET Blazor personal finance web application that helps users track and improve their debt-to-income (DTI) ratio on the way to being "clear to close" on a mortgage. Built for CSE 325's semester-long group project.

## Team

- Shawn Kyne (team of one)

## Project Overview

Buyers working toward mortgage qualification need to know their DTI, stay current on bills, and control discretionary spending — all in one place. This app gives an individual user a simple dashboard to see their current DTI against a goal DTI, track their bills against their paycheck, and log purchases by category to understand where their money is going.

**Target audience:** Individuals actively working to qualify for or close on a mortgage who want a single, simple tool to track their income, bills, and spending against a DTI goal.

**Core features (MVP scope for this course):**
1. **DTI Dashboard** — User enters income and debts; the app calculates current DTI and shows progress toward a user-set goal DTI.
2. **Bill Tracker** — User inputs recurring bills and paycheck(s), and marks bills paid/unpaid to confirm everything is covered each pay period.
3. **Spending Tracker** — User logs purchases with a category (groceries, dining, entertainment, etc.) and views spending totals by category.

Supporting requirements: user authentication (each user's financial data is private to them), CRUD across bills/paychecks/purchases/goals, and deployment to a cloud host.

## Project Ideas Considered

1. **Clear to Close (selected)** — Personal DTI/finance tracker described above. Features: DTI dashboard with goal tracking, bill/paycheck tracker, categorized spending tracker, user auth. Audience: individuals working toward mortgage qualification.
2. **Savings Goal Tracker** — Users create savings goals (e.g. "Emergency Fund – $5,000") and log contributions toward each one. Features: goal CRUD, contribution CRUD, progress visualization, user auth. Audience: individuals building savings habits.
3. **Debt Payoff Planner** — Users list their debts (balance, interest rate, minimum payment) and log payments against them, with the app suggesting a snowball or avalanche payoff order. Features: debt CRUD, payment-log CRUD, payoff-order calculation, user auth. Audience: individuals paying down multiple debts.

## Status

Project setup in progress (Week 2 of the course).
