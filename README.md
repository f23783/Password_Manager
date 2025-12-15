# Password Manager

A secure desktop password management application with a Windows Forms frontend and Python FastAPI backend, designed to help users safely store and manage their passwords.

## Overview

This Password Manager is a full-stack application that combines a C# Windows desktop client with a Python REST API backend and PostgreSQL database. It provides a user-friendly interface for storing, retrieving, and generating secure passwords with cryptographic hashing for authentication.

## Features

### Password Management
- **Secure Storage**: Store passwords with associated titles and usernames
- **Master Key Authentication**: Single master password protects all stored credentials
- **Password Visibility Toggle**: Show/hide stored passwords as needed
- **Copy to Clipboard**: Quick one-click copying of passwords
- **Password Generator**: Built-in cryptographically secure password generator with customizable options:
  - Adjustable length
  - Uppercase/lowercase letters
  - Numbers
  - Special symbols (!@#$%&*()-_=+[]{};:<>?)

### User Interface
- **Login System**: Secure authentication with username and master key
- **User Registration**: Create new accounts with password confirmation
- **Modern UI**: Clean Windows Forms interface with ListView display
- **Organization**: Sidebar navigation for Favorites, Recent items, and Trash

### Security
- SHA256 hashing via custom C/OpenSSL libraries
- Cryptographically secure random password generation
- Password masking in UI by default

## Technology Stack

### Frontend
- **C# .NET Framework 4.7.2**
- **Windows Forms** for desktop UI
- **Visual Studio** project structure

### Backend
- **Python 3.13**
- **FastAPI 0.116.1** - Modern async web framework
- **SQLAlchemy 2.0.43** - Database ORM
- **Uvicorn 0.35.0** - ASGI server
- **Pydantic 2.11.7** - Data validation

### Database
- **PostgreSQL** - Relational database for user and password storage

### Cryptography
- **C/C++** libraries for SHA256 hashing
- **OpenSSL 1.1** (libcrypto, libssl)

## Project Structure

```
Password_Manager/
├── Frontend/
│   └── Password_Manager_Frontend/
│       └── Password_Manager_Frontend/
│           ├── Form1.cs              # Login form
│           ├── RegisterForm.cs       # Registration form
│           ├── MainForm.cs           # Main password manager interface
│           ├── AddEntryForm.cs       # Add new password entry
│           └── Password_Manager_Frontend.csproj
│
├── Backend/
│   ├── Python/
│   │   ├── api.py                    # FastAPI REST endpoints
│   │   └── requirements.txt          # Python dependencies
│   ├── C/
│   │   └── login.c                   # SHA256 hashing implementation
│   └── lib/                          # Compiled cryptography libraries
│       ├── crypt.dll
│       ├── libcrypto-1_1-x64.dll
│       ├── libssl-1_1-x64.dll
│       └── libsha256lib.so
│
└── README.md
```

## Installation & Setup

### Prerequisites
- **Windows OS** (for frontend application)
- **PostgreSQL** installed and running
- **Python 3.13+** installed
- **Visual Studio** (for building the C# frontend)

### Database Setup

1. Install PostgreSQL and create the database:
```sql
CREATE DATABASE passwordmanager;
CREATE USER passapi WITH PASSWORD 'test12';
GRANT ALL PRIVILEGES ON DATABASE passwordmanager TO passapi;
```

2. Connect to the database:
```bash
psql -U passapi -d passwordmanager
```

### Backend Setup

1. Navigate to the backend directory:
```bash
cd Backend/Python
```

2. Create and activate a virtual environment:
```bash
python -m venv venv
venv\Scripts\activate  # On Windows
```

3. Install dependencies:
```bash
pip install -r requirements.txt
```

4. Start the FastAPI server:
```bash
uvicorn api:app --reload
```

The API will be available at `http://localhost:8000`

### Frontend Setup

1. Open the solution in Visual Studio:
```
Frontend/Password_Manager_Frontend/Password_Manager_Frontend.sln
```

2. Build the solution (Build → Build Solution or press `Ctrl+Shift+B`)

3. Run the application (Debug → Start Debugging or press `F5`)

## API Endpoints

The backend provides the following REST API endpoints:

- **POST /createUser** - Create a new user account
  - Parameters: `username`, `masterkey`

- **GET /transferMasterkey** - Retrieve user's master key
  - Parameters: `username`

- **POST /sendNewPassword** - Add a new password entry
  - Parameters: `password`, `title`, `username`, `usr`

- **GET /getAllPasswords** - Retrieve all passwords for a user
  - Parameters: `usr`

## Usage

1. **First Time Setup**:
   - Launch the application
   - Click "Register" to create a new account
   - Enter a username and master key
   - Confirm your master key

2. **Login**:
   - Enter your username and master key
   - Click "Login"

3. **Managing Passwords**:
   - Click "Add Entry" to store a new password
   - Use the password generator for secure random passwords
   - View, copy, or manage existing passwords from the main interface

## Security Notes

This is a development/educational project. For production use, consider:

- Implementing HTTPS/TLS for API communication
- Using environment variables for database credentials
- Implementing proper encryption for stored passwords
- Using parameterized SQL queries to prevent SQL injection
- Adding rate limiting and brute force protection
- Encrypting master keys before database storage
- Implementing proper session management

## Development Status

This project is currently in active development. Recent updates include:
- Core functionality for password storage and retrieval
- User authentication system
- Password generator with customizable options
- REST API implementation
- Windows Forms UI

## Contributing

This is a personal/educational project. If you'd like to contribute:
1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Submit a pull request

## License

This project is open source and available under the [MIT License](LICENSE).

## Contact

For questions or feedback about this project, please open an issue in the repository.

---

<p align="center">
  Made with by <a href="https://github.com/f23783">Arda Fidancı</a>, <a href="https://github.com/EmireGungor">Emire Güngör</a>
</p>
