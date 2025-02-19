import { useEffect, useRef } from 'react'
import { createPortal } from 'react-dom'

interface ModalProps {
    children: React.ReactNode,
    open: boolean
}

const Modal: React.FC<ModalProps> = ({ children, open }) => {
    const dialog = useRef<HTMLDialogElement>(null)
    const key = document.getElementById("modal")

    useEffect(() => {
        const modal = dialog.current

        if(!modal)
            throw new Error()

        if (open) {
            modal.showModal()
        }
        else {
            modal.close()
        }

    }, [open])

    if (!key)
        throw new Error()

    return createPortal(
        <dialog ref={dialog} className="modal-box p-1">{children}</dialog>,
        key)

}

export default Modal