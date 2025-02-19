import { useEffect } from 'react';
import { createContext, useState } from 'react'
import useFetch from '../hooks/useFetch';

type Client = {
    id: number,
    companyName: string,
    address: string,
    owner: string,
    phone: string,
}

const defaultClient: Client = {
    id: 0,
    companyName: "",
    address: "",
    owner: "",
    phone: "",
}

interface ClientContextType {
    clients: Client[];
    client: Client | undefined;
    setClients: React.Dispatch<React.SetStateAction<Client[]>>,
    setClient: React.Dispatch<React.SetStateAction<Client | undefined>>,
    clientId: number | undefined,
    setClientId: React.Dispatch<React.SetStateAction<number | undefined>>,
    isClientCountChanged: boolean,
    setIsClientCountChanged: React.Dispatch<React.SetStateAction<boolean>>
}


export const CompanyInfoContext = createContext<ClientContextType | undefined>(undefined)

type CompanyInfoContextProviderProps = {
    children: React.ReactNode
}

const CompanyInfoContextProvider: React.FC<{ children: React.ReactNode }> = ({ children }) => {
    const [clients, setClients] = useState<Client[]>([])
    const [client, setClient] = useState<Client | undefined>(defaultClient)
    const [clientId, setClientId] = useState<number | undefined>(undefined)
    const [isClientCountChanged, setIsClientCountChanged] = useState(false)   

    useEffect(() => {
        const client = clients.find(x => x.id == clientId)
        setClient(client)
    }, [clientId])

    return (
        <CompanyInfoContext.Provider value={{ clients, setClients, client, setClient, clientId, setClientId, isClientCountChanged, setIsClientCountChanged }}>
            {children}
        </CompanyInfoContext.Provider>
    )
}

export default CompanyInfoContextProvider