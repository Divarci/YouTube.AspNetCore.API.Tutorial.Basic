import { useContext, useEffect, useState } from "react";
import SelectList from "../shared/SelecList";
import AddClientModal from "./AddClientModal";
import useFetch from "../../hooks/useFetch";
import { CompanyInfoContext } from "../../contexts/CompanyInfoContext";

const clientGetConfig: RequestInit = {
    method: "GET",
}

type Client = {
    id: number,
    companyName: string,
    address: string,
    owner: string,
    phone: string
}

type Result = {
    data: Client[],
    statusCode: number,
    errors: string[]
}

export default function Header() {
    const [modalStatus, setModalStatus] = useState(false)
    const context = useContext(CompanyInfoContext)

    if (!context)
        throw new Error()

    const { isClientCountChanged, setIsClientCountChanged } = context

    const { result, SendRequest } = useFetch<Result>(
        "https://localhost:5002/api/Client",
        clientGetConfig)

    useEffect(() => {
        SendRequest(null)
        setIsClientCountChanged(false)
    }, [isClientCountChanged])

    return (
        <>
            <header className="d-flex justify-content-between mt-3 bg-secondary p-2 rounded-3">
                <SelectList
                    defaultOption={{ value: "", label: "Select Client" }}
                    options={result?.data.map(client => ({
                        value: client.id.toString(),
                        label: client.companyName
                    })) || []}
                />
                <button
                    type="button"
                    className="btn btn-outline-light"
                    onClick={() => setModalStatus(status => !status)} >
                    New Client
                </button>
            </header>

            <AddClientModal modalStatus={modalStatus} onClose={setModalStatus} onAction={setIsClientCountChanged} />
        </>
    )
}