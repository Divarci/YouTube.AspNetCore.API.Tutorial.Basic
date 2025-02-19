import { useContext } from "react"
import { CompanyInfoContext } from "../../../contexts/CompanyInfoContext"
import useFetch from "../../../hooks/useFetch"

const CompanyInfo: React.FC = () => {
    const context = useContext(CompanyInfoContext)

    if (!context)
        throw new Error()

    const { client, setIsClientCountChanged, setClientId } = context

    const { SendRequest } = useFetch(
        `https://localhost:5002/api/Client/${client?.id}`,
        { method: "DELETE" })

    return (
        <div className="col-lg-4">
            <div className="card border border-secondary border-3 rounded-3" style={{ height: "450px" }}>
                {!client
                    ? (
                        <div className="d-flex justify-content-center mt-5">
                            <h5>Please select a client</h5>
                        </div>)
                    : (
                        <>
                            <div className="card-header">
                                <h5>{client?.companyName}</h5>
                            </div>
                            <div className="card-body">
                                <h6 className="card-title">Address:</h6>
                                <p className="card-text">{client?.address}</p>
                                <h6 className="card-title">Contact:</h6>
                                <p className="card-text">{client?.phone}</p>
                                <h6 className="card-title">Authorised Person:</h6>
                                <p className="card-text">{client?.owner}</p>
                                <h6 className="card-title">Balance:</h6>
                                <p className="card-text">- $</p>
                            </div>
                            <div className="card-footer d-flex justify-content-between">
                                <div>
                                    <a href="#" className="btn btn-outline-primary me-2">Update</a>
                                    <button
                                        className="btn btn-outline-danger"
                                        onClick={() => {
                                            SendRequest(null)
                                            setIsClientCountChanged(true)
                                            setClientId(undefined)
                                        }}>
                                        Delete
                                    </button>
                                </div>

                                <a href="#" className="btn btn-outline-success">New Invoice</a>
                            </div>
                        </>
                    )
                }

            </div>
        </div>
    )
}

export default CompanyInfo