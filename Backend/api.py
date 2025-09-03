from fastapi import FastAPI

app = FastAPI()

app.state.keyhash = "\0"

@app.post("/transferMasterkey")
def transfer_masterkey(key: str):
    app.state.keyhash = key

