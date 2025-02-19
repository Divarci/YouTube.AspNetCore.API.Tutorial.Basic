import { useContext } from "react";
import { CompanyInfoContext } from "../../contexts/CompanyInfoContext";

type Option= {
    value: string,
    label: string
}

interface SelectListProps {
    defaultOption: Option;
    options: Option[]
}

const SelectList: React.FC<SelectListProps> = ({ defaultOption, options = [] }) => {

    const context = useContext(CompanyInfoContext)

    if (!context)
        throw new Error()

    const { setClientId } = context

    return (
        <div className="d-flex align-items-center">
            <select
                className="form-select"
                aria-label="Default select example"
                onChange={(e) => setClientId(Number(e.target.value))}>
                <option value={defaultOption.value}>
                    {defaultOption.label}
                </option>
                {
                    options.map((item) =>
                        <option
                            key={item.value}
                            value={item.value}>
                            { item.label }
                        </option>)
                }
            </select>
        </div>
    )
}

export default SelectList