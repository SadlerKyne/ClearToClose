# Clear to Close

A .NET Blazor web application for tracking mortgage loan files through the closing process — from application to "clear to close." Built for CSE 325's semester-long group project.

## Team

- Sadler Kyne (team of one)

## Project Overview

Loan officers and processors juggle a checklist of outstanding conditions (income verification, appraisal, title work, insurance, etc.) for every loan file before it can close. This app gives a processor a simple dashboard to create loan files, attach the conditions required to close each one, track their status, and see at a glance which files are "clear to close" versus still pending.

**Target audience:** Mortgage loan processors and loan officers at a small lending office who need a lightweight way to track closing conditions without a full enterprise loan-origination system.

**Core features (MVP scope for this course):**
- User authentication (loan processor accounts)
- CRUD for loan files (borrower name, loan amount, target closing date)
- CRUD for closing conditions attached to each loan file (description, status: pending/received/waived)
- Dashboard view showing each loan file's overall clear-to-close status
- Deployed to a cloud host

This is a scoped-down, from-scratch .NET Blazor rebuild of a concept originally prototyped in JavaScript/Node as a personal project with my wife ([Mortgage_DTI](https://github.com/Aracelikyne/Mortgage_DTI)); this repository is new, independent code written for this course.

## Project Ideas Considered

1. **Clear to Close (selected)** — Mortgage closing-condition tracker described above. Features: loan file CRUD, condition checklist CRUD, auth, status dashboard. Audience: mortgage loan processors/officers.
2. **Household Chore Tracker** — A Blazor app for assigning and tracking recurring household chores/tasks among family members, with completion history. Features: task CRUD, user auth per household member, completion logging, simple points/streak tracking. Audience: families/roommates.
3. **Simple Study Deck App** — A flashcard study tool where users create decks and cards and track review progress. Features: deck/card CRUD, user auth, basic spaced-repetition-style status per card. Audience: students studying for exams.

## Status

Project setup in progress (Week 2 of the course).
