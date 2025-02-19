import { useEffect } from "react"
import useFetch from "../../hooks/useFetch"
import Modal from "../shared/Modal"

const clientPostConfig: RequestInit = {
    method: "POST",
    headers: {
        "Content-Type": "application/json"
    }
}

type Client = {
    id: number,
    companyName: string,
    address: string,
    owner: string,
    phone: string
}

type CreateClient = {
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

interface AddClientModalProps {
    modalStatus: boolean
    onClose: React.Dispatch<React.SetStateAction<boolean>>
    onAction: React.Dispatch<React.SetStateAction<boolean>>
}

const AddClientModal: React.FC<AddClientModalProps> = ({ modalStatus, onClose, onAction }) => {

    const { result, SendRequest } = useFetch<Result>(
        "https://localhost:5002/api/Client",
        clientPostConfig)

    function handleFormSubmit(formData: FormData) {
        const companyName = formData.get("companyName")?.toString()
        const phone = formData.get("phone")?.toString()
        const owner = formData.get("owner")?.toString()
        const address = formData.get("address")?.toString()

        if (!companyName || !phone || !owner || !address)
            throw new Error()

        const newClient: CreateClient = {
            companyName: companyName,
            address: address,
            owner: owner,
            phone: phone
        }

        const body: BodyInit = JSON.stringify(newClient)

        SendRequest(body)
    }

    useEffect(() => {
        if (result?.statusCode === 201) {
            onAction(true)
            onClose(prev => !prev)
        }
    }, [result])

    return (
        <Modal open={modalStatus}>
            <div className="card">
                <div className="card-header fs-3 ">
                    Add New Client
                </div>
                <div className="card-body">
                    <form action={handleFormSubmit}>
                        <div className="form-group mb-2">
                            <label htmlFor="companyName">Company Title</label>
                            <input type="text" className="form-control" id="companyName" name="companyName" />
                        </div>

                        <div className="form-group mb-2">
                            <label htmlFor="address">Address</label>
                            <input type="text" className="form-control" id="address" name="address" />
                        </div>
                        <div className="row mb-2">
                            <div className="form-group col-lg-6">
                                <label htmlFor="owner">Authorised Person</label>
                                <input type="text" className="form-control" id="owner" name="owner" />
                            </div>
                            <div className="form-group col-lg-6">
                                <label htmlFor="phone">Contact</label>
                                <input type="number" className="form-control" id="phone" name="phone" />
                            </div>
                        </div>
                        <div className="d-flex justify-content-between">
                            <button type="submit" className="btn btn-primary">Submit</button>
                            <button type="button" className="btn btn-outline-primary" onClick={() => onClose(prev => !prev)}>Close</button>
                        </div>
                    </form>
                </div>
            </div>





        </Modal>
    )
}

export default AddClientModal