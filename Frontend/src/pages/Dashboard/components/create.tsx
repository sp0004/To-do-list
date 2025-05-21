import { Box, Modal, Typography } from "@mui/material"
import { useState } from "react"
import '../../../styles/styles.css'

const style = {
    position: 'absolute',
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    width: 400,
    bgcolor: 'background.paper',
    border: '2px solid #000',
    boxShadow: 24,
    pt: 2,
    px: 4,
    pb: 3,
  };


function CreateTask(open:boolean) {
    const [Open, isOpen] = useState(open)
    const [close, isClosed] = useState(false)
    
 
    console.log("kkk")
    return (
        <Modal
            open={Open}
            onClose={() => isClosed(!close)}
            aria-labelledby="modal-modal-title"
            aria-describedby="modal-modal-description">
            <Box sx={style}>
                <Typography id="modal-modal-title" variant="h6" component="h2">
                    Text in a modal
                </Typography>
                <Typography id="modal-modal-description" sx={{ mt: 2 }}>
                    Duis mollis, est non commodo luctus, nisi erat porttitor ligula.
                </Typography>
            </Box>
        </Modal>
    )
}

export default CreateTask