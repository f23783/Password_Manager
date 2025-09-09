from fastapi import FastAPI
import sqlalchemy as db
from sqlalchemy.orm import MappedAsDataclass, declarative_base

Base = declarative_base()
engine = db.create_engine('postgresql+psycopg2://passapi:A36473rda@localhost:5432/passwordmanager')
app = FastAPI()

app.state.keyhash = "\0"

@app.get("/transferMasterkey")
def transfer_masterkey(usrname: str):
    with engine.connect() as conn:
        query = conn.execute(db.text(f"SELECT masterkey FROM users WHERE username = '{usrname}'"))
        for row in query:
            return row[0]

@app.post("/createUser")
def create_usr(usrname: str, masterkey: str):
    class Table(Base):
        __tablename__ = usrname

        id = db.Column(db.Integer, primary_key=True, autoincrement=True)
        password = db.Column(db.String, nullable=False)
 
    with engine.connect() as conn: 
        query = db.text("INSERT INTO users (username, masterkey) VALUES (:username, :masterkey)")
        conn.execute(query, {"username": usrname, "masterkey": masterkey})
        conn.commit()
    Base.metadata.create_all(engine)

@app.post("/sendNewPassword")
def send_new_pass(password: str, usr: str):
    with engine.connect() as conn:
        query = db.text(f"INSERT INTO {usr} (password) VALUES (:password)")
        conn.execute(query, {"password": password})
        conn.commit()

@app.get("/getAllPasswords")
def get_all_passwords(usr: str):
    with engine.connect() as conn:
        query = conn.execute(db.text(f"SELECT password FROM {usr}"))
        passwords = []
        for row in query:
            passwords.append(row[0])
    return passwords




