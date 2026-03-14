import { Bowler } from "../models/Bowler";

type Props = {
    bowlers: Bowler[];
};

const BowlerTable = ({ bowlers }: Props) => {
    return (
        <table className="table table-striped">
            <thead>
                <tr>
                    <th>Bowler Name</th>
                    <th>Team</th>
                    <th>Address</th>
                    <th>City</th>
                    <th>State</th>
                    <th>Zip</th>
                    <th>Phone</th>
                </tr>
            </thead>
            <tbody>
                {bowlers.map((b) => (
                    <tr key={b.bowlerId}>
                        <td>
                            {b.firstName} {b.middleInit && b.middleInit + " "} {b.lastName}
                        </td>
                        <td>{b.teamName}</td>
                        <td>{b.address}</td>
                        <td>{b.city}</td>
                        <td>{b.state}</td>
                        <td>{b.zip}</td>
                        <td>{b.phoneNumber}</td>
                    </tr>
                ))}
            </tbody>
        </table>
    );
};

export default BowlerTable;
