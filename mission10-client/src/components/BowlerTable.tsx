import { Bowler } from "../models/Bowler";

interface Props {
  bowlers: Bowler[];
}

export default function BowlerTable({ bowlers }: Props) {
  return (
    <table border={1} cellPadding="10">
      <thead>
        <tr>
          <th>First Name</th>
          <th>Middle Init</th>
          <th>Last Name</th>
          <th>Team</th>
          <th>Address</th>
          <th>City</th>
          <th>State</th>
          <th>Zip</th>
          <th>Phone</th>
        </tr>
      </thead>
      <tbody>
        {bowlers.map((bowler, index) => (
          <tr key={index}>
            <td>{bowler.bowlerFirstName}</td>
            <td>{bowler.bowlerMiddleInit}</td>
            <td>{bowler.bowlerLastName}</td>
            <td>{bowler.teamName}</td>
            <td>{bowler.bowlerAddress}</td>
            <td>{bowler.bowlerCity}</td>
            <td>{bowler.bowlerState}</td>
            <td>{bowler.bowlerZip}</td>
            <td>{bowler.bowlerPhoneNumber}</td>
          </tr>
        ))}
      </tbody>
    </table>
  );
}

