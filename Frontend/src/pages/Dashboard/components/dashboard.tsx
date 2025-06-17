import { Button, Paper, Table, TableBody, TableCell, TableHead, TableRow } from "@mui/material"
import CreateTask from "./create"
import { useState } from "react";



function Dashboard() {
    const list_of_tasks = [{ "task": "first task", "due_date": "today" }, { "task": "second task", "due_date": "tomorrow" }]
     const [open, isOpen] = useState(false);

    // Define the handleClick function
    const handleClick = () => {
        isOpen(true); // Example: open the create task dialog
    };

    const handleClose = () => {
        isOpen(!open)
    }

    return (
        <div>
            <h1>
                To Do list
            </h1>
            <div>
                <Button onClick={handleClick}>Create tasks</Button>
            </div>
            <div>
                <Paper sx={{ height: '100%', width: '100%' }}>
                    <Table>
                        <TableHead>
                            <TableRow>
                                <TableCell>Task Name</TableCell>
                                <TableCell> Due Date</TableCell>
                                <TableCell> Created Date</TableCell>
                                <TableCell> Comments</TableCell>
                                <TableCell> Update</TableCell>
                                <TableCell> Delete</TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {list_of_tasks.map(a => <TableRow><TableCell>{a.task}</TableCell><TableCell>{a.due_date}</TableCell></TableRow>)}
                        </TableBody>

                    </Table>
                </Paper>
            </div>
            <CreateTask open={open} isOpen={handleClose} />
        </div>
    )
}


export default Dashboard
